using System;
using System.Diagnostics;

namespace Day6
{
    internal class Program
    {
        static void findPatern(int numberOfCharacters)
        {
            string lines = System.IO.File.ReadAllText(@"C:\Users\gtasr\OneDrive\Namizje\code\advent-of-code\Day6TuningTrouble\PuzzleInput.txt");
            List<char> usedChar = new List<char>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (usedChar.Contains(lines[i]))
                {
                    usedChar = new List<char>();
                }
                else
                {
                    usedChar.Add(lines[i]);
                }
                if (usedChar.Count() == numberOfCharacters)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }
        static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();
            // First half
            Program.findPatern(4);
            // Second half
            Program.findPatern(14);
            stopwatch.Stop();
            Console.WriteLine("The program took " + stopwatch.Elapsed + " seconds");
        }
    }
}