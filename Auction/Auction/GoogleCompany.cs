﻿using System;
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

        public override bool IsPartOfTheSale()
        {
            return true;
        }

        public override int MakeANewOffer()
        {
            return 4;
        }

        public override int MakeANewOfferWhenSaleEnd()
        {
            return 4;
        }

        
        public override int SetStrartPrice()
        {
            return 4;
        }
    }
}
