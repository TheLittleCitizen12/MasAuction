
using System;

namespace Auction
{
    class Program
    {
        static void Main(string[] args)
        {
            Office office = new Office(true, true, false, true, 50, 7, "Rotchild 6, Tel-Aviv");
            Console.WriteLine(office.Address);
            Console.ReadLine();
            
        }
    }
}
