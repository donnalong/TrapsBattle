using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapsBattle.ViewModels
{
    public class EffectSlotViewModel : ViewModelBase
    {
        private EffectSuit effectSuit;
        public EffectSuit EffectSuit
        {
            get { return effectSuit; }
            set { SetProperty(ref effectSuit, value); }
        }

        private EffectClass effectClass;
        public EffectClass EffectClass
        {
            get { return effectClass; }
            set { SetProperty(ref effectClass, value); }
        }

        private int effectMaxLevel;
        public int EffectMaxLevel
        {
            get { return effectMaxLevel; }
            set { SetProperty(ref effectMaxLevel, value); }
        }

        public ObservableCollection<EffectViewModel> SlottedEffects
        {
            get;
        } = new ObservableCollection<EffectViewModel>();

        public EffectViewModel ActiveEffect
        {
            get
            {
                if(SlottedEffects.Count > 0)
                {
                    return SlottedEffects[SlottedEffects.Count - 1];
                }

                return null;
            }
        }

        public EffectSlotViewModel()
        {
            SlottedEffects.CollectionChanged += SlottedEffects_CollectionChanged;
        }

        private void SlottedEffects_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(ActiveEffect));
        }

        public void ToggleFlipActiveEffect()
        {
            if(ActiveEffect != null)
            {
                ActiveEffect.IsFlipped = !ActiveEffect.IsFlipped;
            }
        }

        public void NextRound()
        {
            if(ActiveEffect != null)
            {
                ActiveEffect.NextRound();
            }
        }
    }
}
