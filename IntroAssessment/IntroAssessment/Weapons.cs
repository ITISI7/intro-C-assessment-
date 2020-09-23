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
        public string[] name =
        {
            "iron sword", "steel sword","sliver sword", "flaming rapier", "void sword",
            "muramasa", "night edge","iron greatsword","steel greatsword", "sliver greatsword",
            "excailbur", 

        };
        
        Player player = new Player();
        
        

        // to get data input from main and assign it 
        public void BuyWeapon(int weaponName, int price, int weaponDamage, int weaponWeight)
        {


            if (player.gold >= price)
            {
                itemName = name[weaponName];
                damage = weaponDamage;
                weight = weaponWeight;
                Console.WriteLine("You bought an " + itemName);
                player.gold -= price;
                Console.WriteLine("You have " + player.gold + " gold left");

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
