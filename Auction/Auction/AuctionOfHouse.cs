using System;
using System.Collections.Generic;
using System.Text;

namespace Auction
{
    class AuctionOfHouse : Auction
    {
        public AuctionOfHouse(string id, int startPrice, int JumpSize)
        {
            _id = id;
            _startPrice = startPrice;
            _jumpSize = JumpSize;

        }
    }
}
