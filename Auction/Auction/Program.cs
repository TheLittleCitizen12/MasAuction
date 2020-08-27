
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
            
            Office office = new Office(true, true, false, true, 50, 7, "Rotchild 6, Tel-Aviv");
           
            var auctionOfHouse = new AuctionOfHouse("1", 20, 10);
            var google = new GoogleCompany("google");
            auctionOfHouse.AddAgentToList(google);
            var ramiLevi = new RamiLevi("Rami Levi");
            auctionOfHouse.AddAgentToList(ramiLevi);
            auctionOfHouse.StartAuction(office);


        }
    }
}
