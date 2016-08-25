using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamedCodes
{
    class HumanGenerator
    {
        public Human CreateHuman(int ucn)
        {
            Human human = new Human();
            human.Ucn = ucn;
            if (ucn % 2 == 0)
            {
                human.name = "Батката";
                human.sex = sex.Male;
            }
            else
            {
                human.name = "Мацето";
                human.sex = sex.Female;
            }

            return human;
        }
    }
}
