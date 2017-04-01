﻿using System;
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
            EffectSlotViewModel effectSlot = e.ClickedItem as EffectSlotViewModel;

            if(effectSlot != null)
            {
                effectSlot.ToggleFlipActiveEffect();
            }
        }
    }
}
