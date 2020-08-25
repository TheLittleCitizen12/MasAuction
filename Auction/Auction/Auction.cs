using System;
using System.Collections.Generic;
using System.Text;

namespace Auction
{
    abstract class Auction
    {
        string proudoctName;
        int StartPrice;
        int JumpSize;
        string id;
        DateTime timer;
        DateTime strartTime;
        List<Agent> AgentList;
        event Action<string> StartSale;

        public void SendNoticeOfAuctionStart()
        {

        }
        public void ShowInfomation()
        {

        }

        public void SendUpdatePrice()
        {

        }

        public void DeclreEndOfSale()
        {

        }
        public void DeclareOnWinner()
        {

        }

    }

    

}
