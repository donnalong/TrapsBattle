using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TrapsBattle.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TrapsBattle.Controls
{
    public sealed partial class EffectSlot : UserControl
    {
        private List<SolidColorBrush> Backgrounds = new List<SolidColorBrush>()
        {
            new SolidColorBrush(Colors.DarkGray),
            new SolidColorBrush(Colors.Gray),
            new SolidColorBrush(Colors.LightGray)
        };

        private const int StackedCardPositionDelta = -5;

        public EffectSlotViewModel EffectSlotViewModel
        {
            get { return (EffectSlotViewModel)GetValue(EffectSlotViewModelProperty); }
            set { SetValue(EffectSlotViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EffectSlotViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EffectSlotViewModelProperty =
            DependencyProperty.Register("EffectSlotViewModel", typeof(EffectSlotViewModel), typeof(EffectSlot), new PropertyMetadata(null));

        public EffectSlot()
        {
            this.InitializeComponent();
        }

        private void SlottedEffect_OnEffectViewModelChanged()
        {
            int numberRectsDifferent = EffectSlotViewModel.SlottedEffects.Count - SlottedEffectGrid.Children.Count;

            bool removeRects = numberRectsDifferent < 0;
            bool addRects = numberRectsDifferent > 0;

            if (addRects || removeRects)
            {
                if (addRects)
                {
                    for (int i = 0; i < numberRectsDifferent; i++)
                    {
                        Border border = CreateNewBorder();

                        SlottedEffectGrid.Children.Insert(0, border);
                    }
                }
                else
                {
                    for (int i = 0; i < -numberRectsDifferent; i++)
                    {
                        if (SlottedEffectGrid.Children.Count > 1)
                        {
                            SlottedEffectGrid.Children.RemoveAt(0);
                        }
                    }
                }

                RepositionRects();
            }
        }

        private Border CreateNewBorder()
        {
            Border border = new Border();
            Rectangle rect = new Rectangle();
            TranslateTransform transform = new TranslateTransform();

            rect.Width = SlottedEffect.ActualWidth;
            rect.Height = SlottedEffect.ActualHeight;

            border.BorderBrush = new SolidColorBrush(Colors.Black);
            border.BorderThickness = new Thickness(1);
            border.Background = Backgrounds[(SlottedEffectGrid.Children.Count - 1) % Backgrounds.Count];

            border.RenderTransform = transform;

            return border;
        }

        private void RepositionRects()
        {
            //Don't move the visible effect either
            int blankRects = SlottedEffectGrid.Children.Count - 2;

            Border border;
            TranslateTransform transform;

            for (int i = blankRects; i >= 0; i--)
            {
                border = SlottedEffectGrid.Children[i] as Border;

                if (border != null)
                {
                    transform = border.RenderTransform as TranslateTransform;

                    transform.X = StackedCardPositionDelta * (SlottedEffectGrid.Children.Count - i - 1);
                    transform.Y = StackedCardPositionDelta * (SlottedEffectGrid.Children.Count - i - 1);
                }
            }
        }
    }
}
