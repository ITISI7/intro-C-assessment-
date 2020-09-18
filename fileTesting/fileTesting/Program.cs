using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace fileTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = ("TextFile1.txt");
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();
            foreach(string line in lines)
            {
                Console.WriteLine(line);
            }
            lines.Add("sliver sword, 800,12");
            File.WriteAllLines(filePath, lines);
            Console.ReadLine();
        }
    }
}
