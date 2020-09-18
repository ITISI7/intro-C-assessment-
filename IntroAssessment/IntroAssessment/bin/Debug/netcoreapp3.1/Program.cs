using System;
using System.Threading;
using System.IO;
using System.Net.NetworkInformation;
using CsvHelper;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.Buffers;
using System.Security.Cryptography.X509Certificates;

namespace IntroAssessment
{

    struct ShopWeaponsInv
    {
        string name;
        int price;
        int damage;
        int weight;

        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public int Damage { get => damage; set => damage = value; }
        public int Weight { get => weight; set => weight = value; }


    }
    class Program
    {
        static void Main(string[] args)
        {
            ShopWeaponsInv[] WeaponInShop;
           
            using (var reader = new StreamReader("Weapons.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                System.Collections.Generic.IEnumerable<ShopWeaponsInv> records =
                 csv.GetRecords<ShopWeaponsInv>();
                WeaponInShop = records.ToArray<ShopWeaponsInv>();
            }

            Player player = new Player();
            Items item = new Items();
            Weapons weapon = new Weapons();


            Console.WriteLine("Weclome to my shop, what would you like to do?\nbuy \nsell \nleave");
            bool menu = true;
            bool shopping = false;
            // Game Loop
            while (menu)
            {

                string command = Console.ReadLine();
                // Player Input 
                if (command == "buy")
                {

                    shopping = true;
                    Console.WriteLine("what would you like to buy?");
                    Console.WriteLine("player gold: " + player.gold);
                    foreach (ShopWeaponsInv tmp in WeaponInShop)
                    {
                        Console.WriteLine(tmp.Name + ": " + tmp.Price + " gold" );
                        


                    }
                    Console.WriteLine("Type leave to exit buy menu");
                    menu = false;


                }
                else if (command == "sell")
                {
                    Console.WriteLine("what would you like to sell?");

                }
                else if (command == "leave")
                {
                    Console.WriteLine("do come again");
                    player.lines.Clear();
                    File.WriteAllLines(player.filePath, player.lines);
                    menu = false;


                }
                else if (command == "inv")
                {
                    player.DisplayedInv();
                    Console.WriteLine("gold: " + player.gold);
                }
                // if player type anything that not in the game
                else
                {
                    Console.WriteLine("invadle");
                }
                while (shopping)
                {
                    string command2 = Console.ReadLine();
               
                    switch (command2)
                    {
                        
                        case "leave":
                        case "quit":
                        case "exit":
                        Console.WriteLine("Do come back soon \nwhat would you like to do now?");
                        shopping = false;
                        menu = true;
                            break;
                        case "ironsword":
                        case "iron sword":
                        weapon.BuyWeapon("iron sword", 200, 5, 5);
                        player.lines.Add(weapon.weaponName + " Damage: " + weapon.damage + "   weight:" + weapon.weight);
                        File.WriteAllLines(player.filePath, player.lines);
                            break;
                        case "steelsword":
                        case "steel sword":
                        weapon.BuyWeapon("steel sword", 400, 8, 10);
                        player.lines.Add(weapon.weaponName + "Damage: " + weapon.damage + "   weight:" + weapon.weight);
                        File.WriteAllLines(player.filePath, player.lines);
                            break;
                        case "sliversword":
                        case "sliver sword":
                            weapon.BuyWeapon("sliver sword", 400, 8, 10);
                            player.lines.Add(weapon.weaponName + "Damage: " + weapon.damage + "   weight:" + weapon.weight);
                            File.WriteAllLines(player.filePath, player.lines);
                            break;


                    }

                }

            }
        }
    }
}
