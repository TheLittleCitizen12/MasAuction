using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Client;


namespace Auction
{
    class Mas
    {
        
        List<Auction> auctionsList = new List<Auction>();
        List<Property> propertyList = new List<Property>();
        public void CreatePropery()
        {
            for (int i = 0; i < 5; i++)
            {
                Random rand1 = new Random();
                bool airConditioner = rand1.Next(0, 3) > 0;
                bool protection = rand1.Next(0, 3) > 0;
                bool accessToMainRoad = rand1.Next(0, 3) > 0;
                bool accessForDisabled = rand1.Next(0, 3) > 0;
                int numOfToiletCubicles = rand1.Next(1, 30);
                int numOfDiningAreas = rand1.Next(1, 10);
                int streetNumber = rand1.Next(1, 15);
                Office office = new Office(airConditioner, protection, accessToMainRoad, accessForDisabled, numOfToiletCubicles, 7, "Rotchild {streetNumber}, Tel-Aviv");
                AddPropertyToList(office);
            }

        }

        public void AddPropertyToList(Property property)
        {
            propertyList.Add(property);
        }

        public void CreateAuction()
        {
            for (int i = 1; i < 6; i++)
            {
                Random rand1 = new Random();
                string id = Convert.ToString(i);
                int startPrice = rand1.Next(1, 50);
                int jumpSize = rand1.Next(1, 50);
                var auctionOfHouse = new AuctionOfHouse(id, startPrice, jumpSize);
                AddAuctionToList(auctionOfHouse);
            }
        }
        public void AddAuctionToList(Auction auction)
        {
            auctionsList.Add(auction);
        }

        public void startAuctions(Client.AgentFactory agentFactory.)
        {
            for (int i = 0; i < auctionsList.Count; i++)
            {
                int num = i;
                var task = Task.Factory.StartNew(() =>
                {
                    auctionsList[num].StartAuction(propertyList[num], AgentsList);
                });
                
            }
        }


    }
}
