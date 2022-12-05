using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    class day4
    {
        public static void run()
        {
            string loc = System.IO.Directory.GetCurrentDirectory() + "/days/day4/input.txt";

            if (File.Exists(loc))
            {
                int i = 0;
                int overlaps = 0;
                using (StreamReader sr = File.OpenText(loc))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] sp = s.Split(',', '-');

                        int ll = int.Parse(sp[0]);
                        int lr = int.Parse(sp[1]);

                        int rl = int.Parse(sp[2]);
                        int rr = int.Parse(sp[3]);

                        List<int> job1 = new List<int>();
                        for (int j = ll; j < lr + 1; j++)
                            job1.Add(j);

                        List<int> job2 = new List<int>();
                        for (int j = rl; j < rr + 1; j++)
                            job2.Add(j);

                        int p = Math.Max(lr, rr);
                        for (int j = Math.Min(ll,rl); j < p+1; j++)
                        {
                            if(job1.Contains(j) && job2.Contains(j))
                            {
                                overlaps++;
                                break;
                            }
                        }

                        if (ll >= rl && lr <= rr)
                        {
                            i++;
                            //Console.WriteLine("True");
                        }
                        else if (ll <= rl && lr >= rr)
                        {
                            i++;
                            //Console.WriteLine("True");
                        }
                        //else
                        //{
                        //    Console.WriteLine("False");
                        //}
                    }
                    Console.WriteLine(i);
                    Console.WriteLine(overlaps);
                }
            }
        }

        public static void run2()
        {
            string loc = System.IO.Directory.GetCurrentDirectory() + "/days/day4/input.txt";

            if (File.Exists(loc))
            {
                int i = 0;
                using (StreamReader sr = File.OpenText(loc))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                    }
                }
            }
        }
    }
}
