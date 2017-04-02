using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapsBattle.ViewModels
{
    public class EffectsSheetViewModel : ViewModelBase
    {
        public ObservableCollection<EffectSlotViewModel> Slots
        {
            get;
        } = new ObservableCollection<EffectSlotViewModel>();

        public EffectsSheetViewModel()
        {
        }

        internal void NextRound()
        {
            foreach (EffectSlotViewModel effectSlot in Slots)
            {
                effectSlot.NextRound();
            }
        }
    }
}
