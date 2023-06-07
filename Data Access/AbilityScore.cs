using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class AbilityScore
    {
        public string name { get; private set; }
        public int score { get; private set; }
        public int modifier { get; private set; }

        private int modifierCalc(int score)
        {
            int result = (score - 10) / 2;
            if (score < 10 && score % 2 == 1)
            {
                result--;
            }
            return result;
        }

        public AbilityScore(string name, int score)
        {
            this.name = name;
            this.score = score;
            modifier = modifierCalc(score);
        }
    }
}
