using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public static class DALFactory
    {
        public static Ability GetAbility(int unlockLevel, int ID)
        {
            return new Ability(unlockLevel, ID);
        }

        public static IDAL GetDAL()
        {
            return new DAL();
        }
    }
}
