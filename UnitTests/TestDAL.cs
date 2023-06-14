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
            return new List<String>() { "Dwarf", "Elf", "Dragonborn" };
        }

        public List<String> GetSubraces(string RaceName)
        {
            switch(RaceName)
            {
                case "Dwarf":
                    return new List<String>() { "Hill Dwarf", "Mountain Dwarf" };
                case "Elf":
                    return new List<String>() { "High Elf", "Wood Elf", "Dark Elf (Drow)" };
                case "Dragonborn":
                    return new List<String>();
                default:
                    return null;
            }
        }

        public List<String> GetClasses()
        {
            return new List<String>() { "Barbarian", "Rogue" };
        }

        public List<String> GetSubclasses(string ClassName)
        {
            switch(ClassName)
            {
                case "Barbarian":
                    return new List<String>() { "Path of the Berserker", "Path of the Zealot" };
                case "Rogue":
                    return new List<String>() { "Thief", "Assassin" };
                default:
                    return null;
            }
        }

        public List<Ability> GetAbilities(string RaceName, string ClassName, string SubraceName, string SubclassName)
        {
            List<Ability> returnlist = new List<Ability>();

            switch(RaceName)
            {
                case "Dwarf":
                    returnlist.Add(DALFactory.GetAbility(0, 1));
                    returnlist.Add(DALFactory.GetAbility(0, 2));
                    returnlist.Add(DALFactory.GetAbility(0, 3));
                    break;
                case "Elf":
                    returnlist.Add(DALFactory.GetAbility(0, 4));
                    returnlist.Add(DALFactory.GetAbility(0, 5));
                    break;
                case "Dragonborn":
                    break;
            }
            switch(ClassName)
            {
                case "Barbarian":
                    returnlist.Add(DALFactory.GetAbility(1, 8));
                    returnlist.Add(DALFactory.GetAbility(2, 9));
                    returnlist.Add(DALFactory.GetAbility(2, 10));
                    break;
                case "Rogue":
                    returnlist.Add(DALFactory.GetAbility(1, 16));
                    returnlist.Add(DALFactory.GetAbility(2, 17));
                    break;
            }
            switch(SubraceName)
            {
                case "Hill Dwarf":
                    break;
                case "Mountain Dwarf":
                    break;
                case "High Elf":
                    returnlist.Add(DALFactory.GetAbility(0, 1));
                    break;
                case "Wood Elf":
                    returnlist.Add(DALFactory.GetAbility(0, 1));
                    returnlist.Add(DALFactory.GetAbility(0, 6));
                    break;
                case "Dark Elf (Drow)":
                    returnlist.Add(DALFactory.GetAbility(0, 21));
                    returnlist.Add(DALFactory.GetAbility(0, 7));
                    break;
            }
            switch(SubclassName)
            {
                case "Path of the Berserker":
                    returnlist.Add(DALFactory.GetAbility(3, 11));
                    break;
                case "Path of the Zealot":
                    returnlist.Add(DALFactory.GetAbility(3, 12));
                    returnlist.Add(DALFactory.GetAbility(3, 13));
                    break;
                case "Thief":
                    returnlist.Add(DALFactory.GetAbility(3, 18));
                    returnlist.Add(DALFactory.GetAbility(3, 19));
                    break;
                case "Assassin":
                    returnlist.Add(DALFactory.GetAbility(3, 20));
                    break;
            }

            return returnlist;
        }

        public List<String> GetProficiencies(string ClassName)
        {
            switch(ClassName)
            {
                case "Barbarian":
                    return new List<String>() { "Animal Handling", "Athletics", "Intimidation", "Nature", "Perception", "Survival" };
                case "Rogue":
                    return new List<String>() { "Acrobatics", "Athletics", "Deception", "Insight", "Intimidation", "Investigation", "Perception", "Performance", "Persuasion", "Sleight of Hand", "Stealth" };
                default:
                    return null;
            }
        }

        public int GetProficiencyAmount(string ClassName)
        {
            switch(ClassName)
            {
                case "Barbarian":
                    return 2;
                case "Rogue":
                    return 4;
                default:
                    return 0;
            }
        }
    }
}
