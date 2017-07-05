using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TrapsBattle.Tools;
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

        private const int StackedCardPositionDelta = 5;

        public Effect GetSlottedEffect
        {
            get { return SlottedEffect; }
        }


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

                RecalculateWidths();
                RepositionRects();
                UpdateSlotHeight(numberRectsDifferent);
            }
        }

        private Border CreateNewBorder()
        {
            Border border = new Border();
            TranslateTransform transform = new TranslateTransform();

            border.BorderBrush = new SolidColorBrush(Colors.Black);
            border.BorderThickness = new Thickness(1);
            border.Background = Backgrounds[(SlottedEffectGrid.Children.Count - 1) % Backgrounds.Count];

            border.RenderTransform = transform;

            return border;
        }

        private void RepositionRects()
        {
            //Don't move the visible effect
            int blankRects = SlottedEffectGrid.Children.Count - 2;

            Border border;
            TranslateTransform transform;

            for (int i = blankRects; i >= 0; i--)
            {
                border = SlottedEffectGrid.Children[i] as Border;

                if (border != null)
                {
                    transform = border.RenderTransform as TranslateTransform;

                    transform.X = StackedCardPositionDelta * i;
                    transform.Y = StackedCardPositionDelta * i;
                }
            }

            SlottedEffectTranslateTransform.X = StackedCardPositionDelta * (blankRects + 1);
            SlottedEffectTranslateTransform.Y = StackedCardPositionDelta * (blankRects + 1);
        }

        private void RecalculateWidths()
        {
            double newWidth = (Width - 10) + ((SlottedEffectGrid.Children.Count - 1) * -(StackedCardPositionDelta * 2));

            if (newWidth > 0)
            {
                foreach (FrameworkElement element in SlottedEffectGrid.Children)
                {
                    element.Width = newWidth;
                }
            }
        }

        private void UpdateSlotHeight(int numberRectsDifferent)
        {
            Thickness margin = SlottedEffectGrid.Margin;

            margin.Bottom += numberRectsDifferent * StackedCardPositionDelta;

            SlottedEffectGrid.Margin = margin;
        }
    }
}
