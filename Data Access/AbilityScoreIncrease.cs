using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class AbilityScoreIncrease : Trait
    {
        public Ability ability { get; private set; }

        public AbilityScoreIncrease(Ability ability) : base(0)
        {
            this.ability = ability;
        }
    }
}
