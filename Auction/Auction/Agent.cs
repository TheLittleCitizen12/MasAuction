using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Auction
{
  
    abstract class Agent
    {
        protected string _name { set; get; }
        public int count = 0;


        public string name
        {
            get
            {
                return _name;
            }
        }

        public bool IsPartOfTheAcution()
        {
            Random rng = new Random();
            bool isPartOfTheSale = rng.Next(0, 3) > 0;
            return isPartOfTheSale;
        }
        
        public int SetStrartPrice(Property property, int startPrice, int jumpSize, string currenWinner)
        {
            if (currenWinner != this.name)
            {
                return this.agentDemend(startPrice,jumpSize,property);
            }
            return 0;

        }

        public abstract int agentDemend(int startPrice, int jumpSize, Property property);







    }
}
