using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class CharacterViewModel : ViewModelBase
    {
        public Dictionary<Stat, int> Stats;
        public Dictionary<Stat, int> DerivedStates;

        public CharacterViewModel()
        {

        }
    }
}
