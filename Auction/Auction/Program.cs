
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
            Mas mas = new Mas();
            mas.CreatePropery();
            mas.CreateAuction();
            mas.CreateAgent();
            mas.startAuctions();
            Console.ReadLine();



        }
    }
}
