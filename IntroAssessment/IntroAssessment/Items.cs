using System;
using System.Collections.Generic;
using System.Text;

namespace IntroAssessment
{
    class Items
    {
        public string itemName;
        public int price;
        public int seling;

        Player player = new Player();
        public void buy(string name, int price)
        {
            if (player.gold >= price)
            {
                Console.WriteLine("You bought an " + name);
                player.gold -= price;
                Console.WriteLine("You have " + player.gold + " gold left");
            }
            else
            {
                Console.WriteLine("Not enough gold");
            }
        }

    }
}
