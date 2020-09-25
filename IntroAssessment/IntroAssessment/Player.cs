using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IntroAssessment
{
     class Player
    {
        public int hp;
        public int mp;
        public int gold = 5000;
        
        public string filePath = ("playerInv.csv");
        public List<string> lines = new List<string>();
        // display text from playerinv file
        public void DisplayedInv()
        {
            
            lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        
        
    }
}
