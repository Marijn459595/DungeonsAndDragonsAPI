using Data_Access;
using DungeonsAndDragonsAPI;
using DungeonsAndDragonsAPI.Controllers;

namespace UnitTests
{
    [TestClass]
    public class Tests
    {
        TestDAL DAL = new TestDAL();

        private BuilderController getController()
        {
            BuilderController returncontroller = new BuilderController();
            returncontroller.DAL = DAL;
            return returncontroller;
        }

        // Rolls stats 100 times and checks that the returned value is always between 3 and 18
        [TestMethod]
        public void RollStats()
        {
            var controller = getController();
            for(int i = 0; i <= 100; i++)
            {
                int rolledStat = controller.RollStat();
                Assert.IsTrue(rolledStat >= 3 && rolledStat <= 18); // Checks if rolled stat is between 3 and 18
            }
        }

        // Gets the modifier for every possible stat (1 to 20) and checks if GetModifier returns the correct modifier
        [TestMethod]
        public void GetModifier()
        {
            var controller = getController();
            // Checks every modifier for stats 1 to 20
            for (int stat = 1; stat <= 20; stat++)
            {
                int modifier = controller.GetModifier(stat);
                int expected;
                switch(stat)
                {
                    case 1:
                        expected = -5;
                        break;
                    case var expression when (stat == 2 || stat == 3):
                        expected = -4;
                        break;
                    case var expression when (stat == 4 || stat == 5):
                        expected = -3;
                        break;
                    case var expression when (stat == 6 || stat == 7):
                        expected = -2;
                        break;
                    case var expression when (stat == 8 || stat == 9):
                        expected = -1;
                        break;
                    case var expression when (stat == 10 || stat == 11):
                        expected = 0;
                        break;
                    case var expression when (stat == 12 || stat == 13):
                        expected = 1;
                        break;
                    case var expression when (stat == 14 || stat == 15):
                        expected = 2;
                        break;
                    case var expression when (stat == 16 || stat == 17):
                        expected = 3;
                        break;
                    case var expression when (stat == 18 || stat == 19):
                        expected = 4;
                        break;
                    case 20:
                        expected = 5;
                        break;
                    default:
                        expected = 1000; // Fails on purpose as stat should never be anything other than a value between 1 and 20
                        break;
                }
                Assert.AreEqual(expected, modifier);
            }
        }

        // Gets a list of all races
        [TestMethod]
        public void GetRaces()
        {
            var controller = getController();

            List<String> expected = new List<String>()
            {
                "Dwarf",
                "Elf",
                "Dragonborn"
            };
            List<String> actual = controller.Races();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        // Gets a list of all subraces for "Dwarf"
        [TestMethod]
        public void GetSubraces()
        {
            var controller = getController();

            List<String> expected = new List<String>()
            {
                "Hill Dwarf",
                "Mountain Dwarf"
            };

            string raceName = controller.Races()[0];
            List<String> actual = controller.Subraces(raceName);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        // Gets a list of all classes
        [TestMethod]
        public void GetClasses()
        {
            var controller = getController();

            List<String> expected = new List<String>()
            {
                "Barbarian",
                "Rogue"
            };

            List<String> actual = controller.Classes();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        // Gets a list of all subclasses for "Barbarian"
        [TestMethod]
        public void GetSubclasses()
        {
            var controller = getController();

            List<String> expected = new List<String>()
            {
                "Path of the Berserker",
                "Path of the Zealot"
            };

            string className = controller.Classes()[0];
            List<String> actual = controller.Subclasses(className);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        // Gets a list of all abilities for "Elf", "Barbarian", "Wood Elf", "Path of the Berserker"
        [TestMethod]
        public void GetAbilities()
        {
            var controller = getController();

            string raceName = controller.Races()[1];
            string subraceName = controller.Subraces(raceName)[0];
            string className = controller.Classes()[0];
            string subclassName = controller.Subclasses(className)[0];

            List<Ability> expected = new List<Ability>()
            {
                DALFactory.GetAbility(0, 4),
                DALFactory.GetAbility(0, 5),
                DALFactory.GetAbility(1, 8),
                DALFactory.GetAbility(2, 9),
                DALFactory.GetAbility(2, 10),
                DALFactory.GetAbility(0, 1),
                DALFactory.GetAbility(3, 11),
            };
            List<Ability> actual = controller.Abilities(raceName, className, subraceName, subclassName);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].unlockLevel, actual[i].unlockLevel);
                Assert.AreEqual(expected[i].ID, actual[i].ID);
            }
        }

        // Gets a list of all proficiencies for "Barbarian"
        [TestMethod]
        public void GetProficiencies()
        {
            var controller = getController();

            string className = controller.Classes()[0];

            List<String> expected = new List<String>()
            {
                "Animal Handling",
                "Athletics",
                "Intimidation",
                "Nature",
                "Perception",
                "Survival"
            };
            List<String> actual = controller.GetProficiencies(className);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        // Gets the number of proficiencies for "Barbarian"
        [TestMethod]
        public void GetProficiencyAmount()
        {
            var controller = getController();

            string className = controller.Classes()[0];

            int expected = 2;

            Assert.AreEqual(expected, controller.GetProficiencyAmount(className));
        }
    }
}