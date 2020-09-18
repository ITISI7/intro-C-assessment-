using System;
using System.Collections.Generic;
using System.Text;

namespace IntroAssessment
{
    class Weapons : Items
    {
        public string weaponName;
        public int damage;
        public int weight;
        Player player = new Player();
        public void BuyWeapon(string name, int price, int weaponDamage, int weaponWeight)
        {
            if (player.gold >= price)
            {
                Console.WriteLine("You bought an " + name);
                player.gold -= price;
                Console.WriteLine("You have " + player.gold + " gold left");
                weaponName = name;
                damage = weaponDamage;
                weight = weaponWeight;
            }
            else
            {
                Console.WriteLine("Not enough gold");
            }
            
        }

    }
}
