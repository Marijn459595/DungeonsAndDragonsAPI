using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class Proficiency : Trait
    {
        public Skill skill { get; private set; }

        public Proficiency(Skill skill, int unlockLevel) : base(unlockLevel)
        {
            this.skill = skill;
        }
    }
}
