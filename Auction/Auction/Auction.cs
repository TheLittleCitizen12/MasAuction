using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auction
{
    abstract class Auction
    {
        string proudoctName;
        protected int _startPrice;
        protected int _jumpSize;
        protected string _id { get; set; }
        DateTime timer;
        DateTime strartTime;
        //public delegate void StartingAuctionEventHandler(object source, EventArgs args);
        //public event StartingAuctionEventHandler StartingAuction;
        List<Agent> AgentsList = new List<Agent>();
        

        public string id

        {
            get
            {
                return _id;
            }
        }
        public int startPrice

        {
            get
            {
                return _startPrice;
            }
        }
        public int jumpSize
        {
            get
            {
                return _jumpSize;
            }
        }
        public void AddAgentToList(Agent agent)
        {
            AgentsList.Add(agent);
        }
        public void StartAuction(Property property)
        {
            for (int i = 0; i < AgentsList.Count; i++)
            {
                int num = i;
                Task.Factory.StartNew(() =>
                {
                    
                    Console.WriteLine("Auction id: {0} is starting,{1} Do you want to participate?", this.id,AgentsList[num].name);
                    if (!AgentsList[num].IsPartOfTheAcution())
                    {
                        AgentsList.RemoveAt(num);
                        Console.WriteLine("{0}: NO", AgentsList[num].name);
                    }
                    else
                    {
                        Console.WriteLine("{0}: YES",AgentsList[num].name);
                    }
                });

                if (AgentsList != null)
                    this.ShowInformation(property);
                

            }

        }
        

        //protected virtual void OnStartingAuction()
        //{
        //    if (StartingAuction != null)
        //        StartingAuction(this, EventArgs.Empty);

        //}
        public void ShowInformation(Property property)
        {
            Console.WriteLine("The property we sale is: {0}\n start price of: {1}\n jump price:{2}\n",property.Address, this.startPrice,this.jumpSize);
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
