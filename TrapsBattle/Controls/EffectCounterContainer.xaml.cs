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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace TrapsBattle.Controls
{
    public sealed partial class EffectCounterContainer : UserControl
    {
        public EffectViewModel EffectViewModel
        {
            get { return (EffectViewModel)GetValue(EffectViewModelProperty); }
            set { SetValue(EffectViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EffectViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EffectViewModelProperty =
            DependencyProperty.Register("EffectViewModel", typeof(EffectViewModel), typeof(EffectCounterContainer), new PropertyMetadata(null));
        
        public EffectCounterContainer()
        {
            this.InitializeComponent();
        }

        private void CounterList_ItemClick(object sender, ItemClickEventArgs e)
        {
            EffectViewModel.IncrementCounter((int)e.ClickedItem);
        }

        private void NewCounterBorder_Click(object sender, RoutedEventArgs e)
        {
            EffectViewModel.AddCounter(1);
        }
    }
}
