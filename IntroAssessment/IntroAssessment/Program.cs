using System;
using System.Threading;
using System.IO;
using System.Net.NetworkInformation;
using CsvHelper;
using System.Globalization;
using System.Linq;


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


                Console.WriteLine("Weclome to my shop, what would you like to do?");
            bool gameover = false;
            // Game Loop
            while(!gameover)
            {
               
                string command = Console.ReadLine();
                // Player Input 
                if (command == "buy")
                {
                    Console.WriteLine("what would you like to buy?");
                    foreach(ShopWeaponsInv tmp in WeaponInShop)
                    {
                        Console.WriteLine(tmp.Name);
                    }

                }
                else if (command == "sell")
                {
                    Console.WriteLine("what would you like to sell?");

                }
                else if (command == "leave")
                {
                    Console.WriteLine("do come again");
                    gameover = true;


                }
                // if player type anything that not in the game
                else
                {
                    Console.WriteLine("invadle");
                }

              }
          }
    }
}
