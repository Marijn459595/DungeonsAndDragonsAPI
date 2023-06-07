using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class Ability : Trait
    {
        public string name { get; private set; }
        public string description { get; private set; }

        public int ID { get; }

        public void SetAbility(string Name, string Description)
        {
            name = Name;
            description = Description;
        }

        public Ability(int UnlockLevel, int ID) : base(UnlockLevel)
        {
            this.ID = ID;
        }
    }
}
