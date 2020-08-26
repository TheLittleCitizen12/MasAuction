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
            return isPartOfTheSale;
        }
        
        public abstract bool IsPartOfTheSale();
        public void GetInfomaitonOnSale(string proudoctnme, int startPrice, int jumpSize, List<Agent> participateList)
        {

        }
        public abstract int SetStrartPrice();

        public abstract int MakeANewOffer();

        public abstract int MakeANewOfferWhenSaleEnd();





    }
}
