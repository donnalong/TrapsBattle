using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapsBattle.ViewModels
{
    public enum EffectSuit
    {
        Power,
        Control,
        Finesse,
        Mental
    }

    public enum EffectClass
    {
        Attack,
        Defense,
        Utility
    }

    public class EffectViewModel : ViewModelBase
    {
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

        public EffectViewModel()
        {

        }
    }
}
