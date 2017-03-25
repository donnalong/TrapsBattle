using System;
using System.Collections.Generic;
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

        private int counter;
        public int Counter
        {
            get { return counter; }
            set { SetProperty(ref counter, value); }
        }
        #endregion

        public EffectViewModel()
        {
        }
    }
}
