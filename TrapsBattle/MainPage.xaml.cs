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
        public ObservableCollection<CharacterViewModel> CharacterViewModels
        {
            get;
        } = new ObservableCollection<CharacterViewModel>();

        public MainPage()
        {
            this.InitializeComponent();

            EffectViewModel.InitSampleEffects();

            InitTestCharacters();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void InitTestCharacters()
        {
            CharacterViewModel sabetha = new CharacterViewModel(agi: 4, cun: 4, dex: 4, hlt: 1, tel: 3, str: 2, wil: 2)
            {
                Name = "Sabetha",
                Level = 3,
                CharacterClass = CharacterClass.Rogue
            };

            CharacterViewModel sayyadina = new CharacterViewModel(agi: 2, cun: 4, dex: 3, hlt: 1, tel: 4, str: 1, wil: 4)
            {
                Name = "Sayyadina",
                Level = 3,
                CharacterClass = CharacterClass.Priest
            };

            CharacterViewModels.Add(sabetha);
            CharacterViewModels.Add(sayyadina);
        }

        private void NewRoundButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (CharacterViewModel character in CharacterViewModels)
            {
                character.NextRound();
            }
        }
    }
}
