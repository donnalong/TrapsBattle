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
    public sealed partial class EffectsSheet : UserControl
    {
        public CharacterViewModel CharacterViewModel
        {
            get { return (CharacterViewModel)GetValue(CharacterViewModelProperty); }
            set { SetValue(CharacterViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CharacterViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CharacterViewModelProperty =
            DependencyProperty.Register("CharacterViewModel", typeof(CharacterViewModel), typeof(EffectsSheet), new PropertyMetadata(null));

        public EffectsSheetViewModel EffectsSheetViewModel
        {
            get { return (EffectsSheetViewModel)GetValue(EffectsSheetViewModelProperty); }
            set { SetValue(EffectsSheetViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EffectSheetViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EffectsSheetViewModelProperty =
            DependencyProperty.Register("EffectsSheetViewModel", typeof(EffectsSheetViewModel), typeof(EffectsSheet), new PropertyMetadata(null));

        public EffectsSheet()
        {
            this.InitializeComponent();
        }

        private void EffectSlotList_ItemClick(object sender, ItemClickEventArgs e)
        {
            EffectSlotViewModel effectSlotViewModel = e.ClickedItem as EffectSlotViewModel;

            if(effectSlotViewModel != null)
            {
                effectSlotViewModel.ToggleFlipActiveEffect();
            }
        }

        public EffectSlotViewModel GetEffectSlotAtPoint(Point point)
        {
            EffectSlotViewModel slot = EffectSlotList.GetItemAtPoint<EffectSlotViewModel>(point);

            if (slot != null)
            {
                return slot;
            }

            return null;
        }

        public Rect? GetBoundingRectForItem(EffectSlotViewModel item)
        {
            return EffectSlotList.GetBoundingRectForItem(item);
        }

        public void HighlightSlot(Point pointInEffectSheet)
        {
            ClearAllHighlights();

            EffectSlotViewModel slot = EffectSlotList.GetItemAtPoint<EffectSlotViewModel>(pointInEffectSheet);

            if (slot != null)
            {
                EffectSlotList.SelectedItem = slot;
            }
        }

        public void ClearAllHighlights()
        {
            EffectSlotList.SelectedItem = null;
        }

        public void DropEffectInSlot(Point point, EffectViewModel effect)
        {
            EffectSlotViewModel effectSlotViewModel = GetEffectSlotAtPoint(point);

            if (effectSlotViewModel != null)
            {
                effectSlotViewModel.PushEffect(effect);

                CharacterViewModel.Effects.Remove(effect);
            }
        }
    }
}
