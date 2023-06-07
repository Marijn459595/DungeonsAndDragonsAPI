using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access;

namespace UnitTests
{
    class TestDAL : IDAL
    {
        public List<String> GetRaces()
        {
            return new List<String>() { "Dwarf" };
        }

        public int GetRaceID(string RaceName)
        {
            return 0;
        }

        public List<String> GetSubraces(string RaceName)
        {
            return new List<String>() { "Hill Dwarf" };
        }

        public int GetSubraceID(string SubraceName)
        {
            return 0;
        }

        public List<String> GetClasses()
        {
            return new List<String>() { "Barbarian" };
        }

        public int GetClassID(string ClassName)
        {
            return 0;
        }

        public List<String> GetSubclasses(string ClassName)
        {
            return new List<String>() { "Path of the Berserker" };
        }

        public int GetSubclassID(string SubclassName)
        {
            return 0;
        }

        public List<Ability> GetAbilities(string RaceName, string ClassName, string SubraceName, string SubclassName)
        {
            return new List<Ability>() { new Ability(0, 0), new Ability(0, 1) };
        }

        public List<String> GetProficiencies(string ClassName)
        {
            return new List<String>() { "Athletics", "Acrobatics", "Animal Handling" };
        }

        public int GetProficiencyAmount(string ClassName)
        {
            return 2;
        }
    }
}
