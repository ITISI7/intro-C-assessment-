using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IntroAssessment
{
    class Weapons : Items
    {
        
        public int damage;
        public int weight;
        // arrays of all weapons item
        public string[] name =
        {
            "iron sword", "steel sword","sliver sword", "flaming rapier", "void sword",
            "muramasa", "night edge","iron greatsword","steel greatsword", "sliver greatsword",
            "excailbur", 

        };
        
        Player player = new Player();
        
        

        // to get data input from main and assign it 
        public void BuyWeapon(int weaponName, int weaponsPrice, int weaponDamage, int weaponWeight)
        {


            if (player.gold >= weaponsPrice)
            {
                price = weaponsPrice;
                itemName = name[weaponName];
                damage = weaponDamage;
                weight = weaponWeight;
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
        public void WriteWeaponintoFile()
        {
            player.lines.Add(itemName + " Damage:" + damage + "   weight:" + weight);
            File.WriteAllLines(player.filePath, player.lines);
        }

    }
}
