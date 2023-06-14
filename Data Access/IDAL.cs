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

        List<String> GetSubraces(string RaceName);

        List<String> GetClasses();

        List<String> GetSubclasses(string ClassName);

        List<Ability> GetAbilities(string RaceName, string ClassName, string SubraceName, string SubclassName);

        List<String> GetProficiencies(string ClassName);

        int GetProficiencyAmount(string ClassName);
    }
}
