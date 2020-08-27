using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Client
{
    public class RamiLevi : Agent
    {
        public RamiLevi(string name)
        {
            _name = name;
        }

        public override int agentDemend(int startPrice, int jumpSize)
        {
            int raise = 0;
            if (startPrice < 600)
                raise = startPrice + jumpSize + 30;
            return raise;
        }
    }
}
