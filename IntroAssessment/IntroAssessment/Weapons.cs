﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IntroAssessment
{
    class Weapons : Items
    {
        
        public int damage;
        public int weight;
        Player player = new Player();

        // to get data input from main and assign it 
        public void BuyWeapon(string name, int price, int weaponDamage, int weaponWeight)
        {
            if (player.gold >= price)
            {
                Console.WriteLine("You bought an " + name);
                player.gold -= price;
                Console.WriteLine("You have " + player.gold + " gold left");
                itemName = name;
                damage = weaponDamage;
                weight = weaponWeight;
            }
            else
            {
                Console.WriteLine("Not enough gold");
            }
            
        }
        public void WriteWeaponintoFile()
        {
            player.lines.Add(itemName + " Damage:" + damage + "   weight:" + weight);
            File.WriteAllLines(player.filePath, player.lines);
        }

    }
}
