using System;
using System.Threading;
using System.IO;
using System.Net.NetworkInformation;

namespace IntroAssessment
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Weclome to my shop, what would you like to do?");
            bool gameover = false;
            // Game Loop
            while(!gameover)
            {
               
                string command = Console.ReadLine();
                if(command == "buy")
                {
                    Console.WriteLine("what would you like to buy?");
                }
                if(command == "sell")
                {
                    Console.WriteLine("what would you like to sell?");
                }
                
            }
        }
    }
}
