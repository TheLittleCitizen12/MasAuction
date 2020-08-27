using System;
using System.Collections.Generic;
using System.Text;

namespace Auction
{
    class Facebook : Agent
    {
        public Facebook(string name)
        {
            _name = name;
        }
        public override int agentDemend(int startPrice, int jumpSize, Property property)
        {
            int raise = 0;
            if(startPrice < 600)
                raise = startPrice + jumpSize + 40;
            return raise;
        }
    }
}
