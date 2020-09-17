﻿using System;
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
    struct PlayerInv
    {
        string name;
        public string Name { get => name; set => name = value; }
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
            ShopWeaponsInv[] WeaponInShop;
            PlayerInv[] inv;
            using (var reader = new StreamReader("Weapons.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                System.Collections.Generic.IEnumerable<ShopWeaponsInv> records =
                 csv.GetRecords<ShopWeaponsInv>();
                WeaponInShop = records.ToArray<ShopWeaponsInv>();
            }
            using (var reader = new StreamReader("playerinv.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                System.Collections.Generic.IEnumerable<PlayerInv> records =
                 csv.GetRecords<PlayerInv>();
                inv = records.ToArray<PlayerInv>();
            }

            Player player = new Player();
            Sword sword = new Sword();


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
                        Console.WriteLine(tmp.Name + ": " + tmp.Price + " gold");


                    }
                    menu = false;


                }
                else if (command == "sell")
                {
                    Console.WriteLine("what would you like to sell?");

                }
                else if (command == "leave")
                {
                    Console.WriteLine("do come again");
                    menu = false;


                }
                else if (command == "inv")
                {
                    foreach (PlayerInv tmp in inv)
                    {
                        Console.WriteLine(tmp.Name);
                    }
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
                        case "ironsword":
                        case "iron sword":
                            sword.ironSword();
                            break;
                        case "steelsword":
                        case "steel sword":
                            sword.steelSword();
                            break;
                        case "sliversword":
                        case "sliver sword":
                            sword.SliverSword();
                            break;


                    }

                }

            }
        }
    }
}
