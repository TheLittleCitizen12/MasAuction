using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class AgentFactory
    {
        List<Agent> agentsList = new List<Agent>();
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
            agentsList.Add(agent);
        }

        public List<Agent> SendList()
        {
            return agentsList;
        }

        
    }
}
