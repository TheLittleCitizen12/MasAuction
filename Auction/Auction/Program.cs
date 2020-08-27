﻿
using System;
using System.Collections.Generic;
using Client;


namespace Auction
{
    class Program
    {
        
        public static Random _random = new Random();
        public static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
            
    }
        static void Main(string[] args)
        {
            AgentFactory agentFactory = new AgentFactory();
            agentFactory.CreateAgent();
            List<Agent> agentsList = new List<Agent>();
            agentsList = agentFactory.SendList();
            Mas mas = new Mas();
            mas.CreatePropery();
            mas.CreateAuction();
            mas.startAuctions(agentsList);
            Console.ReadLine();



        }
    }
}
