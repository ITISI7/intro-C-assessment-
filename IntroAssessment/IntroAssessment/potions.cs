using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IntroAssessment
{
    class potions : Items
    {
        Player player = new Player();
        public string potionEffect;
        public void BuyPotions(string name, int price, string effect )
        {
            if (player.gold >= price)
            {
                Console.WriteLine("You bought an " + name);
                player.gold -= price;
                Console.WriteLine("You have " + player.gold + " gold left");
                potionEffect = effect;
                itemName = name;
            }
            else
            {
                Console.WriteLine("Not enough gold");
            }

        }
        public void WritePotionintoFile()
        {
            player.lines.Add(itemName + " Effect:" + potionEffect );
            File.WriteAllLines(player.filePath, player.lines);
        }

    }
}
