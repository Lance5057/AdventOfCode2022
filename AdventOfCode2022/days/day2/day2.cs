using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    class day2
    {
        public static void run()
        {
            string loc = "C:/Users/dnann/source/repos/AdventOfCode2022/AdventOfCode2022/days/day2/input.txt";

            if (File.Exists(loc))
            {
                using (StreamReader sr = File.OpenText(loc))
                {
                    string s;
                    int i = 0;
                    int k = 0;

                    while ((s = sr.ReadLine()) != null)
                    {
                        i += determineOutcome(s);
                        i += determineWorth(s[2]);

                        k += determineOutcome2(s);
                        k += determineWorth2(s[2]);
                    }

                    Console.WriteLine(i);
                    Console.WriteLine(k);
                }
            }
        }

        static int determineOutcome(string s)
        {
            List<string> wins = new List<string> { "A Y", "B Z", "C X" };
            List<string> draws = new List<string> { "A X", "B Y", "C Z" };

            if (wins.Contains(s))
            {
                return 6;
            }
            else if (draws.Contains(s))
            {
                return 3;
            }

            return 0;
        }

        static int determineOutcome2(string s)
        {
            List<string> wins = new List<string> { "A Y", "B Z", "C X" };
            List<string> draws = new List<string> { "A X", "B Y", "C Z" };
            List<string> loses = new List<string> { "A Z", "B X", "C Y" };

            switch (s[2])
            {
                case 'X': return determineWorth(loses.Find(st => st.Contains(s[0]))[2]);
                case 'Y': return determineWorth(draws.Find(st => st.Contains(s[0]))[2]);
                default: return determineWorth(wins.Find(st => st.Contains(s[0]))[2]);
            }
        }

        static int determineWorth(char c)
        {
            switch(c)
            {
                case 'X':
                case 'A': return 1;
                case 'Y':
                case 'B': return 2;
                default: return 3;
            }
        }

        static int determineWorth2(char c)
        {
            switch (c)
            {
                case 'X': return 0;
                case 'Y': return 3;
                default: return 6;
            }
        }
    }
}
