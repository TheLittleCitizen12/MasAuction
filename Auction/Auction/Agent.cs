using System;
using System.Collections.Generic;
using System.Text;

namespace Auction
{
    abstract class Agent
    {
        protected string _name { set; get; }


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
            bool isPartOfTheSale = rng.Next(0, 2) > 0;
            isPartOfTheSale = true;
            return isPartOfTheSale;
        }
        
        public abstract int SetStrartPrice(Property property, int startPrice, int jumpSize);

        public abstract int MakeANewOffer();

        public abstract int MakeANewOfferWhenSaleEnd();





    }
}
