using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    class day3
    {
        public static void run()
        {
            string loc = System.IO.Directory.GetCurrentDirectory()+"/days/day3/input.txt";

            if (File.Exists(loc))
            {
                int i = 0;

                using (StreamReader sr = File.OpenText(loc))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        string split1, split2;
                        char split;

                        split1 = s.Substring(0, s.Length / 2);
                        split2 = s.Substring(s.Length / 2);

                        split = getCommon(split1, split2);
                        i += getPriority(split);
                    }
                }
                Console.WriteLine(i);
            }
            
        }
        public static void runP2()
        {
            string loc = System.IO.Directory.GetCurrentDirectory() + "/days/day3/input.txt";

            if (File.Exists(loc))
            {
                int i = 0;

                using (StreamReader sr = File.OpenText(loc))
                {
                    while(!sr.EndOfStream)
                    {
                        char c = getCommon(sr.ReadLine(), sr.ReadLine(), sr.ReadLine());
                        i += getPriority(c);
                    }
                }
                Console.WriteLine(i);
            }
        }

            private static int getPriority(char split)
        {
            int i;
            if (!char.IsUpper(split))
                i = split - 96;
            else
                i = split - (65 - 27);
            return i;
        }

        private static char getCommon(params string[] strings)
        {
            bool[] common = new bool[26*2];
            for (int i = 0; i < common.Length; i++)
                common[i] = true;

            for (int i = 0; i < strings.Length; i++)
            {
                bool[] currentCommon = new bool[26 * 2];

                for (int j = 0; j < strings[i].Length; j++)
                {

                    if (!char.IsUpper(strings[i][j]))
                    {
                        if (common[strings[i][j] - 'a'])
                            currentCommon[strings[i][j] - 'a'] = true;
                    }
                    else
                    {
                        if (common[strings[i][j] - 'A' +26])
                            currentCommon[strings[i][j] - 'A' + 26] = true;
                    }
                }
                Array.Copy(currentCommon, 0, common, 0, 26 * 2);
            }
            for (int i = 0; i < 26; i++)
            {
                if (common[i])
                    return (char)(i + 97);
            }
            for (int i = 26; i < 26*2; i++)
            {
                if (common[i])
                    return (char)(i + 65-26);
            }
            return 'a';
        }
    }
}
