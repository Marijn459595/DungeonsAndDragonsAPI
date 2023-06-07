using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public interface IDAL
    {
        List<String> GetRaces();

        int GetRaceID(string RaceName);

        List<String> GetSubraces(string RaceName);

        int GetSubraceID(string SubraceName);

        List<String> GetClasses();

        int GetClassID(string ClassName);

        List<String> GetSubclasses(string ClassName);

        int GetSubclassID(string SubclassName);

        List<Ability> GetAbilities(string RaceName, string ClassName, string SubraceName, string SubclassName);

        List<String> GetProficiencies(string ClassName);

        int GetProficiencyAmount(string ClassName);
    }
}
