using Microsoft.AspNetCore.Mvc;
using Data_Access;

namespace DungeonsAndDragonsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuilderController : Controller
    {
        public IDAL DAL = DALFactory.GetDAL();
        Random rng = new Random();

        [HttpGet("Races")]
        public List<String> Races()
        {
            return DAL.GetRaces();
        }

        [HttpGet("Subraces/{RaceName}")]
        public List<String> Subraces(string RaceName)
        {
            return DAL.GetSubraces(RaceName);
        }

        [HttpGet("Classes")]
        public List<String> Classes()
        {
            return DAL.GetClasses();
        }

        [HttpGet("Subclasses/{ClassName}")]
        public List<String> Subclasses(string ClassName)
        {
            return DAL.GetSubclasses(ClassName);
        }

        [HttpGet("Abilities/{RaceName}/{ClassName}/{SubraceName}/{SubclassName}")]
        public List<Ability> Abilities(string RaceName, string ClassName, string SubraceName, string SubclassName)
        {
            return DAL.GetAbilities(RaceName, ClassName, SubraceName, SubclassName);
        }

        [HttpGet("DiceRoll/{d}")]
        public int DiceRoll(int d)
        {
            return rng.Next(1, d + 1);
        }

        [HttpGet("RollStat")]
        public int RollStat()
        {
            int[] diceRolls = new int[4];
            int lowestRoll = 20;
            for(int number = 0; number < 4; number++)
            {
                diceRolls[number] = DiceRoll(6);
                if (diceRolls[number] < lowestRoll)
                {
                    lowestRoll = diceRolls[number];
                }
            }
            int stat = 0;
            for(int number = 0; number < 4; number++)
            {
                stat += diceRolls[number];
            }
            stat -= lowestRoll;
            return stat;
        }

        [HttpGet("GetModifier/{stat}")]
        public int GetModifier(int stat)
        {
            int modifier = (stat - 10) / 2;
            if (stat < 10 && stat % 2 == 1)
            {
                modifier--;
            }
            return modifier;
        }

        [HttpGet("GetProficiencies/{ClassName}")]
        public List<String> GetProficiencies(string ClassName)
        {
            return DAL.GetProficiencies(ClassName);
        }

        [HttpGet("GetProficiencyAmount/{ClassName}")]
        public int GetProficiencyAmount(string ClassName)
        {
            return DAL.GetProficiencyAmount(ClassName);
        }
    }
}
