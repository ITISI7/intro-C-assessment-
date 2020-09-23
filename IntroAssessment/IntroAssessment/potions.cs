﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IntroAssessment
{
    class potions : Items
    {
        Player player = new Player();
        public string potionEffect;
        public string[] name =
        {
            "health potion","magic potion","strength potion","defense potion","speed potion",
        };
        public void BuyPotions(int potionName, int price, string effect )
        {
            if (player.gold >= price)
            {
                potionEffect = effect;
                itemName = name[potionName];
                Console.WriteLine("You bought an " + itemName);
                player.gold -= price;
                Console.WriteLine("You have " + player.gold + " gold left");
                
            }
            else
            {
                Console.WriteLine("Not enough gold");
            }

        }
        public void WritePotionintoFile()
        {
            player.lines.Add(itemName + "   Effect: " + potionEffect );
            File.WriteAllLines(player.filePath, player.lines);
        }

    }
}
