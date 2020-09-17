using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace IntroAssessment
{
    class Sword
    {
        Player player = new Player();
        public void ironSword()
        {
            if (player.gold >= 200)
            {
                Console.WriteLine("You bought an iron sword");
                player.gold -= 200;
                Console.WriteLine("You have " + player.gold + " gold left");
            }
            else
            {
                Console.WriteLine("Not enough gold");
            }
        }
        public void steelSword()
        {
            if (player.gold >= 400)
            {
                Console.WriteLine("you bought an steel sword");
                player.gold -= 400;
                Console.WriteLine("You have " + player.gold + " gold left");
            }
            else
            {
                Console.WriteLine("Not enough gold");
            }
        }
        public void SliverSword()
        {
            if (player.gold >= 800)
            {
                Console.WriteLine("you bought an sliver sword");
                player.gold -= 800;
                Console.WriteLine("You have " + player.gold + " gold left");
            }
            else
            {
                Console.WriteLine("Not enough gold");
            }
        }
    }
}
