using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class GoogleCompany : Agent
    {
        public GoogleCompany(string name)
        {
            _name = name;
        }

        public override int agentDemend(int startPrice, int jumpSize)
        {
            int raise = 0;
            if (startPrice < 600)
                raise = startPrice + jumpSize + 40;
            return raise;
        }

       
    }
}
