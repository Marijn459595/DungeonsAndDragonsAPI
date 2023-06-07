using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class Trait
    {
        public int unlockLevel { get; set; }

        public Trait(int unlockLevel)
        {
            this.unlockLevel = unlockLevel;
        }
    }
    /* 0 = Extra Attack
     * 1 = Ability, text
     * 
     * Proficiencies:
     * 0 = skill
     * 1 = other
     */
}
