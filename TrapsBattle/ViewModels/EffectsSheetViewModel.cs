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
        public ObservableCollection<EffectViewModel> Effects
        {
            get;
        } = new ObservableCollection<EffectViewModel>();

        public ObservableCollection<EffectSlotViewModel> Slots
        {
            get;
        } = new ObservableCollection<EffectSlotViewModel>();

        public EffectsSheetViewModel()
        {
            InitSampleEffects();
            InitSampleSlots();
        }

        private void InitSampleEffects()
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

        private void InitSampleSlots()
        {
            Slots.Add(new EffectSlotViewModel()
            {
                EffectSuit = EffectSuit.Power,
                EffectClass = EffectClass.Attack,
                EffectMaxLevel = 1
            });

            Slots.Add(new EffectSlotViewModel()
            {
                EffectSuit = EffectSuit.Mental,
                EffectClass = EffectClass.All,
                EffectMaxLevel = 1
            });

            EffectSlotViewModel effectSlotVM = new EffectSlotViewModel()
            {
                EffectSuit = EffectSuit.All,
                EffectClass = EffectClass.Utility,
                EffectMaxLevel = 2
            };

            effectSlotVM.SlottedEffects.Add(Effects[0]);
            effectSlotVM.SlottedEffects.Add(Effects[2]);
            effectSlotVM.SlottedEffects.Add(Effects[1]);

            Slots.Add(effectSlotVM);

            effectSlotVM = new EffectSlotViewModel()
            {
                EffectSuit = EffectSuit.Control,
                EffectClass = EffectClass.All,
                EffectMaxLevel = 1
            };

            effectSlotVM.SlottedEffects.Add(Effects[3]);

            Slots.Add(effectSlotVM);
        }
    }
}
