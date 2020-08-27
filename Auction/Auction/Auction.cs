using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Auction
{
    
    abstract class Auction
    {
        private static object _locker = new object();
        protected int _startPrice;
        protected int _jumpSize;
        public bool isActive = true;
        protected string _id { get; set; }
        List<Agent> AgentsList = new List<Agent>();
        ConcurrentStack<string> currentWiner = new ConcurrentStack<string>();
        

        public string id

        {
            get
            {
                return _id;
            }
        }
        public int startPrice

        {
            set
            {
                _startPrice = value;
            }
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
                
                var goThrowTheList = Task.Factory.StartNew(() =>
                {
                    int num = i;
                    Console.WriteLine("Auction id: {0} is starting,{1} Do you want to participate?", this.id, AgentsList[num].name);
                    if (!AgentsList[num].IsPartOfTheAcution())
                    {
                        Console.WriteLine("{0}: NO\n", AgentsList[num].name);
                        AgentsList.RemoveAt(num);
                        i--;
                        
                    }
                    else
                    {
                        Console.WriteLine("{0}: YES\n", AgentsList[num].name);
                    }
                    
                });
                goThrowTheList.Wait();
            }
            

            if (AgentsList.Count != 0)
                this.ShowInformation(property);
            else
            {
                Console.WriteLine("The auction: {0} is canceled because there are no participants\n", this.id);
            }
            

        }
        

        public void ShowInformation(Property property)
        {
            System.Timers.Timer timer1 = new System.Timers.Timer();
            timer1.Elapsed += new ElapsedEventHandler(OnTimeEvent);
            timer1.Interval = 2000;
            
            Console.WriteLine("The property we sale is: {0}\n start price of: {1}\n jump price:{2}\n", property.Address, this.startPrice, this.jumpSize);
            while (this.isActive)
            {
                timer1.Start();
                for (int j = 0; j < AgentsList.Count; j++)
                {
                    int num = j;
                    var goThrowTheList = Task.Factory.StartNew(() =>
                    {
                        
                        lock (_locker)
                        {

                            if (AgentsList[num].SetStrartPrice(property, this.startPrice, this.jumpSize) >= this.startPrice + this.jumpSize && isActive == true)
                            {
                                timer1.Start();
                                currentWiner.Push(AgentsList[num].name);
                                int currentRaise = AgentsList[num].SetStrartPrice(property, this.startPrice, this.jumpSize);
                                this.startPrice = currentRaise;
                                Console.WriteLine("{0}: {1}\n", AgentsList[num].name, this.startPrice);
                            }
                        }

                    });
                    goThrowTheList.Wait();
                }
            }
            Console.WriteLine("Last time 1..2..");
            this.isActive = true;
            while (this.isActive)
            {
                timer1.Start();
                for (int j = 0; j < AgentsList.Count; j++)
                {
                    int num = j;
                    var goThrowTheList = Task.Factory.StartNew(() =>
                    {

                        lock (_locker)
                        {

                            if (AgentsList[num].SetStrartPrice(property, this.startPrice, this.jumpSize) >= this.startPrice + this.jumpSize)
                            {
                                timer1.Start();
                                currentWiner.Push(AgentsList[num].name);
                                int currentRaise = AgentsList[num].SetStrartPrice(property, this.startPrice, this.jumpSize);
                                this.startPrice = currentRaise;
                                 
                                Console.WriteLine("{0}: {1}\n", AgentsList[num].name, this.startPrice);
                            }
                        }

                    });
                    goThrowTheList.Wait();
                }
            }
            string winnerName;
            bool isSuccess = currentWiner.TryPop(out winnerName);
            Console.WriteLine("The Winner is:{0}", winnerName);


        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            this.isActive = false;
        }



        public void DeclreEndOfSale()
        {

        }
        public void DeclareOnWinner()
        {

        }

        

    }

    

}
