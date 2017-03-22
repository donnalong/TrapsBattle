using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TrapsBattle
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<EffectViewModel> Effects = new ObservableCollection<EffectViewModel>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Effects.Add(new EffectViewModel()
            {
                Name = "Mighty Blow",
                Suit = EffectSuit.Power,
                Class = EffectClass.Attack,
                Level = 1,
                Description = "x2 damage against targets with Stunned"
            });

            Effects.Add(new EffectViewModel()
            {
                Name = "Block",
                Suit = EffectSuit.Control,
                Class = EffectClass.Defense,
                Level = 1,
                Description = "+2 Agility energizing effect, +3 resistence, may flip an opponent's Finesse effect when targetted"
            });

            Effects.Add(new EffectViewModel()
            {
                Name = "Saboteur",
                Suit = EffectSuit.Finesse,
                Class = EffectClass.Utility,
                Level = 1,
                Description = "May choose to replace an effect of target's choice when inflicting sabotage effects"
            });

            Effects.Add(new EffectViewModel()
            {
                Name = "Foresight",
                Suit = EffectSuit.Mental,
                Class = EffectClass.Utility,
                Level = 1,
                Description = "Flip to look at another character's effects"
            });
        }
    }
}
