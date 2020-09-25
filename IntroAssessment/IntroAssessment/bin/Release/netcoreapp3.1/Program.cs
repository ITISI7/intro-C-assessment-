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
using System.Net;
using System.Runtime.CompilerServices;

namespace IntroAssessment
{
    struct ShopPotionInv
    {
        string name;
        int price;
        string effect;

        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public string Effect { get => effect; set => effect = value; }

    }

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
            // data forom file
            ShopWeaponsInv[] WeaponInShop;
            ShopPotionInv[] PotionInShop;

            using (var reader = new StreamReader("Weapons.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                System.Collections.Generic.IEnumerable<ShopWeaponsInv> records =
                 csv.GetRecords<ShopWeaponsInv>();
                WeaponInShop = records.ToArray<ShopWeaponsInv>();
            }
            using (var reader = new StreamReader("potions.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                System.Collections.Generic.IEnumerable<ShopPotionInv> records =
                 csv.GetRecords<ShopPotionInv>();
                PotionInShop = records.ToArray<ShopPotionInv>();
            }

            Player player = new Player();
            Items item = new Items();
            Weapons weapon = new Weapons();
            potions potion = new potions();



            bool menu = true;
            bool shopping = false;
            bool buyWeapons = false;
            bool buyPotions = false;
            
            // menu game loop
            Console.WriteLine("Weclome to my shop, what would you like to do?\ntype help for help");
            
            while (menu)
            {


                string command = Console.ReadLine();
                // Player Input 
                if (command == "buy" || command == "purchase")
                {

                    shopping = true;
                    Console.WriteLine("what would you like to buy?");
                    Console.WriteLine("player gold: " + player.gold);
                    Console.WriteLine("Weapons \nPotions \nleave");

                    menu = false;


                }
                else if (command == "sell")
                {
                    Console.WriteLine("what would you like to sell?");

                }
                else if (command == "leave")
                {
                    Console.WriteLine("do come again");
                    // clear everything from playerinv file when you quit the game
                    player.lines.Clear();
                    File.WriteAllLines(player.filePath, player.lines);
                    menu = false;


                }
                else if (command == "inv" || command == "bag")
                {
                    Console.WriteLine("gold: " + player.gold);
                    player.DisplayedInv();
                    
                }
                else if (command == "help")
                {
                    Console.WriteLine("Your options are:\nbuy \nsell \ninv \nleave");
                }
                else if(command == "add gold")
                {
                    Console.WriteLine("1000 gold was added to your inv");
                    player.gold += 1000;
                }
                // if player type anything that not in the game
                else
                {
                    Console.WriteLine("invalided");
                }
                // game loop of buying menu after when player input "buy"
                while (shopping)
                {
                    string command2 = Console.ReadLine();
                    
                    switch (command2)
                    {
                        // leave shop menu to main menu
                        case "leave":
                        case "quit":
                            menu = true;
                            Console.WriteLine("Weclome to my shop, what would you like to do?\ntype help for help");
                            shopping = false;
                            break;
                        // to enter weapons shop menu
                        case "weapons":
                            buyWeapons = true;
                            shopping = false;
                            Console.WriteLine("What would you like to buy?");
                            // displayed list from weapon.csv file
                            foreach (ShopWeaponsInv tmp in WeaponInShop)
                            {
                                Console.WriteLine(tmp.Name + ": " + tmp.Price + " gold");
                            }
                            Console.WriteLine("type quit to exit weapons shop menu");
                            break;
                        case "potions":
                            buyPotions = true;
                            shopping = false;
                            Console.WriteLine("What would you like to buy?");
                            foreach (ShopPotionInv tmp in PotionInShop)
                            {
                                Console.WriteLine(tmp.Name + ": " + tmp.Price + " gold");
                            }
                            Console.WriteLine("Type quit to exit potion shop");
                            break;
                        default:
                            Console.WriteLine("invalided");
                            break;


                    }

                }
                // buying weapons menu game loop
                while (buyWeapons)
                {
                    string command3 = Console.ReadLine();

                    switch (command3)
                    {
                        // to leave weapons shop menu into main menu
                        case "leave":
                        case "quit":
                        case "exit":
                            buyWeapons = false;
                            Console.WriteLine("Weclome to my shop, what would you like to do?\ntype help for help");
                            menu = true;
                            break;
                        // all weapons the player can buy
                        case "ironsword":
                        case "iron sword":
                            // to give data to Buyweapon method
                            weapon.BuyWeapon(0, 200, 5, 5);
                            // to write into playerInv.csv file
                            weapon.WriteWeaponintoFile();
                            break;
                        case "steelsword":
                        case "steel sword":
                            weapon.BuyWeapon(1, 400, 8, 10);
                            weapon.WriteWeaponintoFile();
                            break;
                        case "sliversword":
                        case "sliver sword":
                            weapon.BuyWeapon(2, 400, 8, 10);
                            weapon.WriteWeaponintoFile();
                            break;
                        case "flamingrapier":
                        case "flaming rapier":
                            weapon.BuyWeapon(3, 1000, 10, 2);
                            weapon.WriteWeaponintoFile();
                            break;
                        case "voidsword":
                        case "void sword":
                            weapon.BuyWeapon(4, 1000, 15, 5);
                            weapon.WriteWeaponintoFile();
                            break;
                        case "muramasa":
                            weapon.BuyWeapon(5, 1300, 18, 3);
                            weapon.WriteWeaponintoFile();
                            break;
                        case "nightedge":
                        case "night edge":
                            weapon.BuyWeapon(6, 1200, 20, 8);
                            weapon.WriteWeaponintoFile();
                            break;
                        case "irongreatsword":
                        case "iron greatsword":
                            weapon.BuyWeapon(7, 200, 8, 10);
                            weapon.WriteWeaponintoFile();
                            break;
                        case "steelgreatsword":
                        case "steel greatsword":
                            weapon.BuyWeapon(8, 400, 13, 20);
                            weapon.WriteWeaponintoFile();
                            break;
                        case "slivergreatsword":
                        case "sliver greatsword":
                            weapon.BuyWeapon(9, 800, 16, 12);
                            weapon.WriteWeaponintoFile();
                            break;
                        case "excalibur":
                            weapon.BuyWeapon(10, 1500, 30, 20);
                            weapon.WriteWeaponintoFile();
                            break;
                        default:
                            Console.WriteLine("invalided");
                            break;

                    }

                }
                while (buyPotions)
                {
                    string command4 = Console.ReadLine();
                    switch (command4)
                    {
                        case "leave":
                        case "exit":
                        case "quit":
                            buyPotions = false;
                            Console.WriteLine("Weclome to my shop, what would you like to do?\ntype help for help");
                            menu = true;
                            break;
                        case "healthpotion":
                        case "health potion":
                            potion.BuyPotions(0, 50, "Heals for 10 hp");
                            potion.WritePotionintoFile();
                            break;
                        case "magic potion":
                        case "magicpotion":
                            potion.BuyPotions(1, 50, "recover 10 mp");
                            potion.WritePotionintoFile();
                            break;
                        case "strengthpotion":
                        case "strength potion":
                            potion.BuyPotions(2, 100, "increase strength by 5");
                            potion.WritePotionintoFile();
                            break;
                        case "defensepotion":
                        case "defense potion":
                            potion.BuyPotions(3, 100, "increase defense by 5");
                            potion.WritePotionintoFile();
                            break;
                        case "speedpotion":
                        case "speed potion":
                            potion.BuyPotions(4, 100, "increase speed by 5");
                            potion.WritePotionintoFile();
                            break;
                        case "invisibilitypotion":
                        case "invisibility potion":
                            potion.BuyPotions(5, 200, "turn invisibility for 20 second");
                            potion.WritePotionintoFile();
                            break;
                        default:
                            Console.WriteLine("invalided");
                            break;

                    }
                }
            }
        }                                    
    }
}

