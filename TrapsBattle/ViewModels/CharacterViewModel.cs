using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrapsBattle.Tools;

namespace TrapsBattle.ViewModels
{
    public enum Stat
    {
        Strength,
        Health,
        Dexterity,
        Agility,
        Cunning,
        Willpower,
        Intelligence
    }

    public enum DerivedStat
    {
        Weight,
        PhysicalDamage,
        MentalDamage,
        PhysicalHit,
        MentalHit,
        Evade,
        DamageReduction,
        SkillPoints,
        Sabotage,
        Energy,
        Slots
    }

    public enum CharacterClass
    {
        Generic,
        Warrior,
        Knight,
        Ranger,
        Barbarian,
        Rogue,
        Merchant,
        Mage,
        Priest,
        Wanderer
    }

    public class CharacterViewModel : ViewModelBase
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private int level;
        public int Level
        {
            get { return level; }
            set { SetProperty(ref level, value); }
        }

        private CharacterClass characterClass;
        public CharacterClass CharacterClass
        {
            get { return characterClass; }
            set { SetProperty(ref characterClass, value); }
        }

        public ObservableDictionary<Stat, int> Stats
        {
            get;
        } = new ObservableDictionary<Stat, int>();

        public ObservableDictionary<DerivedStat, int> DerivedStats
        {
            get;
        } = new ObservableDictionary<DerivedStat, int>();

        private EffectsSheetViewModel effectSheet;
        public EffectsSheetViewModel EffectsSheet
        {
            get { return effectSheet; }
            set { SetProperty(ref effectSheet, value); }
        }

        public CharacterViewModel()
        {
            EffectViewModel.InitSampleEffects();

            EffectsSheet = new EffectsSheetViewModel();

            InitTestCharacter();
            InitSampleSlots();
        }

        private void InitTestCharacter()
        {
            Name = "Sabetha";
            Level = 3;
            CharacterClass = CharacterClass.Rogue;

            Stats.Add(Stat.Agility, 4);
            Stats.Add(Stat.Cunning, 4);
            Stats.Add(Stat.Dexterity, 4);
            Stats.Add(Stat.Health, 1);
            Stats.Add(Stat.Intelligence, 3);
            Stats.Add(Stat.Strength, 2);
            Stats.Add(Stat.Willpower, 2);

            CalculateDerivedStats();
        }

        private void CalculateDerivedStats()
        {
            DerivedStats.Add(DerivedStat.DamageReduction, Stats[Stat.Health]);
            DerivedStats.Add(DerivedStat.Energy, Stats[Stat.Willpower]);
            DerivedStats.Add(DerivedStat.Evade, Stats[Stat.Agility]);
            DerivedStats.Add(DerivedStat.MentalDamage, Stats[Stat.Willpower]);
            DerivedStats.Add(DerivedStat.MentalHit, Stats[Stat.Intelligence]);
            DerivedStats.Add(DerivedStat.PhysicalDamage, Stats[Stat.Strength]);
            DerivedStats.Add(DerivedStat.PhysicalHit, Stats[Stat.Dexterity]);
            DerivedStats.Add(DerivedStat.Sabotage, Stats[Stat.Cunning]);
            DerivedStats.Add(DerivedStat.SkillPoints, Stats[Stat.Cunning]);
            DerivedStats.Add(DerivedStat.Slots, Stats[Stat.Intelligence]);
            DerivedStats.Add(DerivedStat.Weight, Stats[Stat.Strength] + Stats[Stat.Health]);
        }

        private void InitSampleSlots()
        {
            foreach (EffectViewModel effect in EffectViewModel.AllEffects)
            {
                EffectsSheet.Effects.Add(effect);
            }

            EffectsSheet.Slots.Add(new EffectSlotViewModel()
            {
                EffectSuit = EffectSuit.Power,
                EffectClass = EffectClass.Attack,
                EffectMaxLevel = 1
            });

            EffectsSheet.Slots.Add(new EffectSlotViewModel()
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

            effectSlotVM.SlottedEffects.Add(EffectsSheet.Effects[0]);
            effectSlotVM.SlottedEffects.Add(EffectsSheet.Effects[2]);
            effectSlotVM.SlottedEffects.Add(EffectsSheet.Effects[1]);

            EffectsSheet.Slots.Add(effectSlotVM);

            effectSlotVM = new EffectSlotViewModel()
            {
                EffectSuit = EffectSuit.Control,
                EffectClass = EffectClass.All,
                EffectMaxLevel = 1
            };

            effectSlotVM.SlottedEffects.Add(EffectsSheet.Effects[3]);

            EffectsSheet.Slots.Add(effectSlotVM);

            effectSlotVM = new EffectSlotViewModel()
            {
                EffectSuit = EffectSuit.Control,
                EffectClass = EffectClass.All,
                EffectMaxLevel = 1
            };

            effectSlotVM.SlottedEffects.Add(EffectsSheet.Effects[4]);

            EffectsSheet.Slots.Add(effectSlotVM);
        }

        public void NextRound()
        {
            EffectsSheet.NextRound();
        }
    }
}
