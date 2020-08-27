using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;


namespace Auction
{
    
    abstract class Auction
    {
        protected static object _locker = new object();
        protected int _startPrice;
        protected int _jumpSize;
        public bool isActive = true;
        public string winnerName = "no one";
        protected string _id { get; set; }
        
        List<string> currentWiner = new List<string>();
        List<Agent> AgentInTheAuction = new List<Agent>();
        protected static Random _random = new Random();

        protected static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }
        


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
        
        public void StartAuction(Property property,List<Agent> AgentsList)
        {
            List<Task> taskList = new List<Task>();
            System.Timers.Timer timer1 = new System.Timers.Timer();
            timer1.Elapsed += new ElapsedEventHandler(OnTimeEvent);
            timer1.Interval = 2000;
            Console.ForegroundColor = GetRandomConsoleColor();

            while (this.isActive)
            {
                for (int j = 0; j < AgentsList.Count; j++)
                {
                    timer1.Start();
                    int num = j;
                    var task = Task.Factory.StartNew(() =>
                    {
                        Console.WriteLine("Auction id: {0} is starting,{1} Do you want to participate?", this.id, AgentsList[num].name);
                        if (AgentsList[num].IsPartOfTheAcution())
                        {
                            timer1.Stop();
                            AgentInTheAuction.Add(AgentsList[num]);
                            Console.WriteLine("{0}: YES\n", AgentsList[num].name);
                        }
                        else
                        {
                            Console.WriteLine("{0}: NO\n", AgentsList[num].name);
                        }
                    });
                    taskList.Add(task);
                    this.isActive = false;
                }
                timer1.Stop();
            }
            Task.WaitAll(taskList.ToArray());
            if (AgentInTheAuction.Count != 0 && this.isActive == false)
                this.ShowInformation(property, AgentInTheAuction);
            else
            {
                Console.WriteLine("The auction: {0} is canceled because there are no participants\n", this.id);
            }

        }





        public void ShowInformation(Property property, List<Agent> AgentInTheAuction)
        {
            List<Task> taskList1 = new List<Task>();
            List<Task> taskList2 = new List<Task>();
            currentWiner.Add("no one");
            System.Timers.Timer timer1 = new System.Timers.Timer();
            timer1.Elapsed += new ElapsedEventHandler(OnTimeEvent);
            timer1.Interval = 2000;
            this.isActive = true;


            Console.WriteLine("The property we sale is: {0}\n start price of: {1}\n jump price:{2}\n", property.Address, this.startPrice, this.jumpSize);
            while (this.isActive)
            {
                timer1.Start();
                for (int j = 0; j < AgentInTheAuction.Count; j++)
                {
                    int num = j;
                    var goThrowTheList = Task.Factory.StartNew(() =>
                    {
                        
                        lock (_locker)
                        {

                            this.winnerName = currentWiner[currentWiner.Count - 1];
                            if (AgentInTheAuction[num].SetStrartPrice(property, this.startPrice, this.jumpSize, winnerName) >= this.startPrice + this.jumpSize && isActive == true)
                            {
                                timer1.Stop();
                                currentWiner.Add(AgentInTheAuction[num].name);
                                int currentRaise = AgentInTheAuction[num].SetStrartPrice(property, this.startPrice, this.jumpSize, winnerName);
                                this.startPrice = currentRaise;
                                Console.WriteLine("{0}: {1}\n", AgentInTheAuction[num].name, this.startPrice);
                            }
                        }

                    });
                    taskList1.Add(goThrowTheList);
                }
            }
            Task.WaitAll(taskList1.ToArray());
            timer1.Stop();
            Console.WriteLine("Last time 1..2..\n");
            this.isActive = true;
            while (this.isActive)
            {
                timer1.Start();
                for (int j = 0; j < AgentInTheAuction.Count; j++)
                {
                    int num = j;
                    var goThrowTheList = Task.Factory.StartNew(() =>
                    {

                        lock (_locker)
                        {
                            this.winnerName = currentWiner[currentWiner.Count - 1];
                            if (AgentInTheAuction[num].SetStrartPrice(property, this.startPrice, this.jumpSize, this.winnerName) >= this.startPrice + this.jumpSize && this.isActive)
                            {
                                timer1.Stop();
                                currentWiner.Add(AgentInTheAuction[num].name);
                                int currentRaise = AgentInTheAuction[num].SetStrartPrice(property, this.startPrice, this.jumpSize, winnerName);
                                this.startPrice = currentRaise;
                                 
                                Console.WriteLine("{0}: {1}\n", AgentInTheAuction[num].name, this.startPrice);
                            }
                        }

                    });
                    taskList2.Add(goThrowTheList);
                }
            }
            Task.WaitAll(taskList2.ToArray());
            timer1.Stop();
            DeclareOnWinner();

        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            this.isActive = false;
        }

        public void DeclareOnWinner()
        {
            Console.WriteLine("The Winner is:{0}\n", this.winnerName);
        }

        

    }

    

}
