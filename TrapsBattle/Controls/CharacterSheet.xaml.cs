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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TrapsBattle.Controls
{
    public sealed partial class CharacterSheet : UserControl
    {
        #region Manipulation Variables
        private EffectViewModel draggedViewModel;
        private EffectSlotViewModel originalSlotViewModel;

        private Point lastManipulationPosition;

        private bool manipulationInitialized = false;

        private enum StartPosition
        {
            PossibleList,
            EffectGrid
        }

        private StartPosition dragStartPosition;

        private bool effectListWasHighlighted = false;
        #endregion

        public CharacterViewModel CharacterViewModel
        {
            get { return (CharacterViewModel)GetValue(CharacterViewModelProperty); }
            set { SetValue(CharacterViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CharacterViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CharacterViewModelProperty =
            DependencyProperty.Register("CharacterViewModel", typeof(CharacterViewModel), typeof(CharacterSheet), new PropertyMetadata(null));

        public CharacterSheet()
        {
            this.InitializeComponent();

            CharacterSheetGrid.ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateY;
        }

        #region Effect Manipulation Events
        private void Grid_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            Point point = e.Position;

            Rect? boundingRect = null;

            bool pointIsInEffectsSheet = CharacterSheetGrid.IsPointInElement(CharacterEffectsSheet, point);
            bool pointIsInEffectsList = CharacterSheetGrid.IsPointInElement(PossibleEffectsList, point);

            if (pointIsInEffectsSheet)
            {
                Point pointInChild = CharacterSheetGrid.TranslatePointToContainer(CharacterEffectsSheet, point);

                originalSlotViewModel = CharacterEffectsSheet.GetEffectSlotAtPoint(pointInChild);

                if(originalSlotViewModel != null)
                {
                    draggedViewModel = originalSlotViewModel.ActiveEffect;

                    boundingRect = CharacterEffectsSheet.GetBoundingRectForItem(originalSlotViewModel);

                    dragStartPosition = StartPosition.EffectGrid;
                }
            }
            else if (pointIsInEffectsList)
            {
                Point pointInChild = CharacterSheetGrid.TranslatePointToContainer(PossibleEffectsList, point);

                draggedViewModel = PossibleEffectsList.GetItemAtPoint<EffectViewModel>(pointInChild);

                dragStartPosition = StartPosition.PossibleList;

                boundingRect = PossibleEffectsList.GetBoundingRectForItem(draggedViewModel);
            }

            if (draggedViewModel != null)
            {
                manipulationInitialized = true;

                DraggableEffect.EffectViewModel = draggedViewModel;

                //Save the initial touch point so we can calculate deltas
                lastManipulationPosition = point;

                DraggableEffect.Height = boundingRect.Value.Height;

                DraggableEffectTranslateTransform.X = boundingRect.Value.X;
                DraggableEffectTranslateTransform.Y = boundingRect.Value.Y;

                DraggableEffect.Visibility = Visibility.Visible;
            }
        }

        private void Grid_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (manipulationInitialized)
            {
                Point deltaPosition = e.Position.SubtractPoint(lastManipulationPosition);

                DraggableEffectTranslateTransform.X += deltaPosition.X;
                DraggableEffectTranslateTransform.Y += deltaPosition.Y;

                lastManipulationPosition = e.Position;

                switch (dragStartPosition)
                {
                    case StartPosition.EffectGrid:
                        {
                            bool pointIsInEffectsList = CharacterSheetGrid.IsPointInElement(PossibleEffectsList, e.Position);

                            if (pointIsInEffectsList)
                            {
                                HighlightEffectsList();
                            }
                            else
                            {
                                RemoveEffectListHighlight();
                            }

                            break;
                        }
                    case StartPosition.PossibleList:
                        {
                            bool pointIsInEffectsSheet = CharacterSheetGrid.IsPointInElement(CharacterEffectsSheet, e.Position);

                            if(pointIsInEffectsSheet)
                            {
                                Point pointInEffectSheet = CharacterSheetGrid.TranslatePointToContainer(CharacterEffectsSheet, e.Position);

                                CharacterEffectsSheet.HighlightSlot(pointInEffectSheet);
                            }

                            break;
                        }
                }
            }
        }

        private void Grid_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (manipulationInitialized)
            {
                DraggableEffect.Visibility = Visibility.Collapsed;

                switch (dragStartPosition)
                {
                    case StartPosition.EffectGrid:
                        {
                            bool pointIsInEffectsList = CharacterSheetGrid.IsPointInElement(PossibleEffectsList, e.Position);

                            if (pointIsInEffectsList)
                            {
                                CharacterViewModel.Effects.Add(draggedViewModel);
                                originalSlotViewModel.PopEffect();
                            }

                            RemoveEffectListHighlight();

                            break;
                        }
                    case StartPosition.PossibleList:
                        {
                            bool pointIsInEffectsSheet = CharacterSheetGrid.IsPointInElement(CharacterEffectsSheet, e.Position);

                            if(pointIsInEffectsSheet)
                            {
                                Point pointInEffectSheet = CharacterSheetGrid.TranslatePointToContainer(CharacterEffectsSheet, e.Position);

                                CharacterEffectsSheet.DropEffectInSlot(pointInEffectSheet, draggedViewModel);
                            }

                            CharacterEffectsSheet.ClearAllHighlights();

                            break;
                        }
                }

                draggedViewModel = null;
            }

            manipulationInitialized = false;
        }

        private void HighlightEffectsList()
        {
            if (!effectListWasHighlighted)
            {
                PossibleEffectsList.Background = new SolidColorBrush(Colors.PaleTurquoise);
            }

            effectListWasHighlighted = true;
        }

        private void RemoveEffectListHighlight()
        {
            if (effectListWasHighlighted)
            {
                PossibleEffectsList.Background = new SolidColorBrush(Colors.White);
            }

            effectListWasHighlighted = false;
        }
        #endregion
    }
}
