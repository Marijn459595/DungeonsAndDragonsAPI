using Microsoft.AspNetCore.Mvc;
using Data_Access;

namespace DungeonsAndDragonsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameRuleController : ControllerBase
    {
        [HttpGet("Dwarf")]
        public Character Dwarf()
        {
            Character dwarf = new Character(16, 14, 13, 8, 10, 10);

            return dwarf;
        }
    }
}
