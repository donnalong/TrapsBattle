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
            EffectSlotViewModel effectSlotviewModel = e.ClickedItem as EffectSlotViewModel;

            if (effectSlotviewModel != null)
            {
                if (CharacterViewModel.SelectedEffect != null)
                {
                    effectSlotviewModel.PushEffect(new EffectViewModel(CharacterViewModel.SelectedEffect));

                    CharacterViewModel.SelectedEffect = null;
                }
                else
                {
                    effectSlotviewModel.ToggleFlipActiveEffect();
                }
            }
        }

        private void EffectSlotList_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            ListViewItemPresenter itemPresenter = e.OriginalSource as ListViewItemPresenter;

            if(itemPresenter != null)
            {
                EffectSlotViewModel effectSlotViewModel = itemPresenter.Content as EffectSlotViewModel;

                if(effectSlotViewModel != null)
                {
                    effectSlotViewModel.PopEffect();
                }
            }
        }
    }
}
