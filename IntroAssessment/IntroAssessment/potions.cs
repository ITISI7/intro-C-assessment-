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
        //array of all potions item
        public string[] name =
        {
            "health potion","magic potion","strength potion","defense potion","speed potion",
            "invisibility potion"
        };
        //to get data input from main and assign it
        public void BuyPotions(int potionName, int potionsPrice, string effect )
        {
            if (player.gold >= potionsPrice)
            {
                price = potionsPrice;
                potionEffect = effect;
                itemName = name[potionName];
                Console.WriteLine("You bought an " + itemName + " for " + price + " gold");
                player.gold -= price;
                Console.WriteLine("You have " + player.gold + " gold left");
                
            }
            else
            {
                Console.WriteLine("Not enough gold");
            }

        }
        // method for wtriting into a file
        public void WritePotionintoFile()
        {
            player.lines.Add(itemName + "   Effect: " + potionEffect );
            File.WriteAllLines(player.filePath, player.lines);
        }

    }
}
