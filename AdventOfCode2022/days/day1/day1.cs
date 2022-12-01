using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class day1
    {
        public static void run()
        {
            string loc = "C:/Users/dnann/source/repos/AdventOfCode2022/AdventOfCode2022/days/day1/input.txt";
            List<int> elves = new List<int>();

            if (File.Exists(loc))
            {
                using (StreamReader sr = File.OpenText(loc))
                {
                    string s;
                    int i = 0;
                    elves.Add(0);

                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s == "")
                        {
                            i++;
                            elves.Add(0);
                        }
                        else
                        {
                            elves[i] += int.Parse(s);
                        }

                        //Console.WriteLine(s);
                    }

                    elves = elves.OrderByDescending(e => e).ToList();

                    Console.WriteLine("Top: " + elves[0]);

                    int combine = elves[0] + elves[1] + elves[2];
                    Console.WriteLine("Top 3: " + combine);
                }
            }
        }
    }
}
