using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace Client
{
  
    abstract class Agent
    {
        protected string _name { set; get; }
        public int count = 0;
        List<Agent> AgentsList = new List<Agent>();


        public string name
        {
            get
            {
                return _name;
            }
        }

        public bool IsPartOfTheAcution()
        {
            Random rng = new Random();
            bool isPartOfTheSale = rng.Next(0, 3) > 0;
            return isPartOfTheSale;
        }
        
        public int SetStrartPrice( int startPrice, int jumpSize, string currenWinner)
        {
            if (currenWinner != this.name)
            {
                return this.agentDemend(startPrice,jumpSize);
            }
            return 0;

        }

        public abstract int agentDemend(int startPrice, int jumpSize);

        public void CreateAgent()
        {
            var google = new GoogleCompany("google");
            AddAgentToList(google);
            var ramiLevi = new RamiLevi("Rami Levi");
            AddAgentToList(ramiLevi);
            var facebook = new Facebook("Facebook");
            AddAgentToList(facebook);
        }

        public void AddAgentToList(Agent agent)
        {
            AgentsList.Add(agent);
        }

        public List<Agent> SendAgentList()
        {
            return AgentsList;
        }







    }
}
