using System;
using System.Collections.Generic;
using System.Text;

namespace Auction
{
    abstract class Agent
    {
        

        public abstract bool IsPartOfTheSale();
        public void GetInfomaitonOnSale(string proudoctnme, int startPrice, int jumpSize, List<Agent> participateList)
        {

        }
        public abstract int SetStrartPrice();

        public abstract int MakeANewOffer();

        public abstract int MakeANewOfferWhenSaleEnd();





    }
}
