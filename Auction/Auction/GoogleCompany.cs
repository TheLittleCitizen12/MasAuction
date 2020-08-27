using System;
using System.Collections.Generic;
using System.Text;

namespace Auction
{
    class GoogleCompany : Agent
    {
        public GoogleCompany(string name)
        {
            _name = name;
        }


        public override int MakeANewOffer()
        {
            return 4;
        }

        public override int MakeANewOfferWhenSaleEnd()
        {
            return 4;
        }

        
        public override int SetStrartPrice(Property property, int startPrice, int jumpSize)
        {
            if(startPrice < 110)
            {
                int raisePrice = startPrice + jumpSize;
                return raisePrice;
            }
            return 0;
            
        }
    }
}
