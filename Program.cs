using System;
using System.Collections.Generic;
using System.Text;

namespace so_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "AAABBCCCCCAADDDBBBEEEEEEETTTQQQQQQQQQQXXXXXXXZZIIIIIIQQQLLLLLPP";
            var output = new List<string>();
            var cnt = 1;

            for (int i = 1; i < input.Length; i++)
            {
                // Console.WriteLine($"WAS: {input[i - 1]}; IS: {input[i]}");
                if (input[i - 1].Equals(input[i])) cnt++;
                else
                {
                    output.Add(input[i-1].ToString());
                    output.Add(cnt.ToString());
                    cnt = 1;
                }
            }

            output.Add(input[input.Length-1].ToString());
            output.Add(cnt.ToString());

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

            Console.ReadLine();
        }
    }
}
