using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    class day5
    {
        public static void run()
        {
            string loc = System.IO.Directory.GetCurrentDirectory() + "/days/day5/input.txt";

            if (File.Exists(loc))
            {
                using (StreamReader sr = File.OpenText(loc))
                {
                    
                    string s;

                    //Crates
                    List<Stack<char>> stacks = setupCrates(sr);

                    //Instructions
                    while ((s = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(s);

                        string[] strings = s.Split(' ');
                        int count = int.Parse(strings[1]);
                        int from = int.Parse(strings[3]);
                        int to = int.Parse(strings[5]);

                        rearrangeCrates(stacks, count, from, to, false);
                    }

                    foreach (Stack<char> st in stacks)
                        Console.Write(st.Pop());
                }
            }

            
        }

        public static void run2()
        {
            string loc = System.IO.Directory.GetCurrentDirectory() + "/days/day5/input.txt";

            if (File.Exists(loc))
            {
                using (StreamReader sr = File.OpenText(loc))
                {

                    string s;

                    //Crates
                    List<Stack<char>> stacks = setupCrates(sr);

                    //Instructions
                    while ((s = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(s);

                        string[] strings = s.Split(' ');
                        int count = int.Parse(strings[1]);
                        int from = int.Parse(strings[3]);
                        int to = int.Parse(strings[5]);

                        rearrangeCrates(stacks, count, from, to, true);
                    }

                    foreach (Stack<char> st in stacks)
                        Console.Write(st.Pop());
                }
            }
        }

        static List<Stack<char>> setupCrates(StreamReader sr)
        {
            List<string> crates = new List<string>();
            string s;
            while ((s = sr.ReadLine()) != "")
            {
                s = s.Replace("[", " ").Replace("]", " ");
                crates.Add(s);
                //Console.WriteLine(s);
            }

            List<Stack<char>> stacks = new List<Stack<char>>();
            string bottom = crates[crates.Count - 1];

            for (int i = 0; i < bottom.Length; i++)
            {
                if (bottom[i] != ' ')
                {
                    Stack<char> nStack = new Stack<char>();

                    for (int j = crates.Count - 2; j >= 0; j--)
                    {
                        if (crates[j][i] != ' ')
                        {
                            nStack.Push(crates[j][i]);
                        }
                    }

                    stacks.Add(nStack);
                }
            }

            return stacks;
        }

        static List<Stack<char>> rearrangeCrates(List<Stack<char>> stacks, int count, int from, int to, bool multi)
        {
            if (!multi)
            {
                for (int i = 0; i < count; i++)
                {
                    char c = stacks[from - 1].Pop();
                    stacks[to - 1].Push(c);
                }
            }
            else
            {
                Stack<char> chars = new Stack<char>();

                for (int i = 0; i < count; i++)
                {
                    chars.Push(stacks[from - 1].Pop());
                }

                for (int i = 0; i < count; i++)
                {
                    stacks[to - 1].Push(chars.Pop());
                }
            }

                return stacks;
        }
    }
}
