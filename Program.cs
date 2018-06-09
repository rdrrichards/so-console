using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace so_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "AAABBCCCCCAADDDBBBEEEEEEETTTQQQQQQQQQQXXXXXXXZZIIIIIIQQQLLLLLPP";
            ProcessTry01(input);
            ProcessTry02(input);
            ProcessTry03(input);

            Console.ReadLine();
        }

        private static void ProcessTry01(string input)
        {
            Console.WriteLine("");
            Console.WriteLine("Process Try I (for)");
            var output = new List<string>();
            var cnt = 1;

            for (int i = 1; i < input.Length; i++)
            {
                // Console.WriteLine($"WAS: {input[i - 1]}; IS: {input[i]}");
                if (input[i - 1].Equals(input[i])) cnt++;
                else
                {
                    output.Add(input[i - 1].ToString());
                    output.Add(cnt.ToString());
                    cnt = 1;
                }
            }

            output.Add(input[input.Length - 1].ToString());
            output.Add(cnt.ToString());

            PrintRebuildOutput(input, output);
        }

        private static void ProcessTry02(string input)
        {
            Console.WriteLine("");
            Console.WriteLine("Process Try II (Linq)");
            var output = new List<string>();
            var cnt = -1;
            var a = new List<char>(input.ToCharArray());
            var was = a[0];
            a.ForEach(c =>
            {
                if (was.Equals(c)) cnt++;
                else
                {
                    cnt++;
                    output.Add(was.ToString());
                    output.Add(cnt.ToString());
                    cnt = 0;
                }
                was = c;
            });

            cnt++;
            output.Add(was.ToString());
            output.Add(cnt.ToString());

            PrintRebuildOutput(input, output);
        }
        private static void ProcessTry03(string input)
        {
            Console.WriteLine("");
            Console.WriteLine("Process Try III (Linq GroupAdjacent)");
            var a = new List<char>(input.ToCharArray());
            var gb = a.GroupAdjacent(c => c).Select(m => new { Value = m.Key, Count = m.Count() }).ToList();

            var rebuild = new StringBuilder();
            gb.ForEach(g => { rebuild.Append(new String(g.Value, g.Count)); });

            Console.WriteLine("These should match:");
            Console.WriteLine(input);
            Console.WriteLine(rebuild.ToString());
        }

        private static void PrintRebuildOutput(string input, List<string> output)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine(output.Count);
            // output.ToList().ForEach(s => Console.WriteLine(s));
            Console.WriteLine(string.Join(",", output.ToArray()));
            Console.WriteLine("---------------------------------------------------");

            var rebuild = new StringBuilder();
            for (int i = 0; i < output.Count; i++)
                rebuild.Append(new String(char.Parse(output[i]), int.Parse(output[++i])));

            Console.WriteLine("These should match:");
            Console.WriteLine(input);
            Console.WriteLine(rebuild.ToString());
        }
    }
}
