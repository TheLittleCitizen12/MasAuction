using System;
using System.Collections.Generic;
using System.Text;

namespace Auction
{
    class RamiLevi : Agent
    {
        public RamiLevi(string name)
        {
            _name = name;
        }
        public override bool IsPartOfTheSale()
        {
            throw new NotImplementedException();
        }

        public override int MakeANewOffer()
        {
            throw new NotImplementedException();
        }

        public override int MakeANewOfferWhenSaleEnd()
        {
            throw new NotImplementedException();
        }

        public override int SetStrartPrice()
        {
            throw new NotImplementedException();
        }
    }
}
