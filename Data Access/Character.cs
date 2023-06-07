using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class Character
    {
        public Race race { get; private set; }
        public Class characterClass { get; private set; }
        public int level { get; private set; }
        public List<AbilityScore> abilityScores { get; private set; }

        public Character(int Str, int Dex, int Con, int Int, int Wis, int Cha)
        {
            level = 1;
            race = Race.Dwarf;
            characterClass = Class.Barbarian;
            abilityScores = new List<AbilityScore>();
            abilityScores.Add(new AbilityScore(AbilityType.Strength.ToString(), Str));
            abilityScores.Add(new AbilityScore(AbilityType.Dexterity.ToString(), Dex));
            abilityScores.Add(new AbilityScore(AbilityType.Constitution.ToString(), Con));
            abilityScores.Add(new AbilityScore(AbilityType.Intelligence.ToString(), Int));
            abilityScores.Add(new AbilityScore(AbilityType.Wisdom.ToString(), Wis));
            abilityScores.Add(new AbilityScore(AbilityType.Charisma.ToString(), Cha));
        }
    }
}
