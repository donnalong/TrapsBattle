using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TrapsBattle.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class EffectSlot : UserControl
    {
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
    }
}
