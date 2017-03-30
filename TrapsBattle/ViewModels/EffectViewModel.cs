using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapsBattle.ViewModels
{
    public enum EffectSuit
    {
        All,
        Power,
        Control,
        Finesse,
        Mental
    }

    public enum EffectClass
    {
        All,
        Attack,
        Defense,
        Utility
    }

    public class EffectViewModel : ViewModelBase
    {
        public static ObservableCollection<EffectViewModel> AllEffects
        {
            get;
        } = new ObservableCollection<EffectViewModel>();

        #region Effect Stats
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private EffectSuit suit;
        public EffectSuit Suit
        {
            get { return suit; }
            set { SetProperty(ref suit, value); }
        }

        private EffectClass effectClass;
        public EffectClass Class
        {
            get { return effectClass; }
            set { SetProperty(ref effectClass, value); }
        }

        private int level;
        public int Level
        {
            get { return level; }
            set { SetProperty(ref level, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
        #endregion

        #region Effect Modifiers
        private bool isFlipped;
        public bool IsFlipped
        {
            get { return isFlipped; }
            set { SetProperty(ref isFlipped, value); }
        }

        public ObservableCollection<int> Counters
        {
            get;
        } = new ObservableCollection<int>();
        #endregion

        public EffectViewModel()
        {
        }

        public void AddCounter(int counterLength)
        {
            Counters.Add(counterLength);
        }

        #region All Effects
        public static void InitSampleEffects()
        {
            EffectViewModel.AllEffects.Add(new EffectViewModel()
            {
                Name = "Mighty Blow",
                Suit = EffectSuit.Power,
                Class = EffectClass.Attack,
                Level = 1,
                Description = "x2 damage against targets with Stunned"
            });

            EffectViewModel effect = new EffectViewModel()
            {
                Name = "Block",
                Suit = EffectSuit.Control,
                Class = EffectClass.Defense,
                Level = 1,
                Description = "+2 Agility energizing effect, +3 resistence, may flip an opponent's Finesse effect when targetted",
            };

            effect.AddCounter(2);
            effect.AddCounter(4);
            effect.AddCounter(1);

            EffectViewModel.AllEffects.Add(effect);

            EffectViewModel.AllEffects.Add(new EffectViewModel()
            {
                Name = "Saboteur",
                Suit = EffectSuit.Finesse,
                Class = EffectClass.Utility,
                Level = 1,
                Description = "May choose to replace an effect of target's choice when inflicting sabotage effects"
            });

            EffectViewModel.AllEffects.Add(new EffectViewModel()
            {
                Name = "Foresight",
                Suit = EffectSuit.Mental,
                Class = EffectClass.Utility,
                Level = 1,
                Description = "Flip to look at another character's effects"
            });

            effect = new EffectViewModel()
            {
                Name = "Foresight",
                Suit = EffectSuit.Mental,
                Class = EffectClass.Utility,
                Level = 1,
                Description = "Flip to look at another character's effects (THIS SHOULD BE FLIPPED)",
                IsFlipped = true
            };

            effect.AddCounter(3);

            EffectViewModel.AllEffects.Add(effect);

            EffectViewModel.AllEffects.Add(new EffectViewModel()
            {
                Name = "Foresight",
                Suit = EffectSuit.Control,
                Class = EffectClass.Utility,
                Level = 1,
                Description = "Flip to look at another character's effects (THIS SHOULD BE FLIPPED)",
                IsFlipped = true
            });
        }

        #endregion
    }
}
