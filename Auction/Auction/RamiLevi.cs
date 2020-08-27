using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Auction
{
    class RamiLevi : Agent
    {
        public RamiLevi(string name)
        {
            _name = name;
        }


        public override int MakeANewOffer()
        {
            throw new NotImplementedException();
        }

        public override int MakeANewOfferWhenSaleEnd()
        {
            throw new NotImplementedException();
        }

        public override int SetStrartPrice(Property property, int startPrice, int jumpSize, string currenWinner)
        {
            if (startPrice < 100 && currenWinner != this.name)
            {
                int raisePrice = startPrice + jumpSize;
                return raisePrice;
            }
            return 0;

        }
    }
}
