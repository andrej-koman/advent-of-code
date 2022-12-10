using System;

namespace Day4
{
    internal class Program
    {
        public static void getRangeNumbers (string[] range, ref HashSet<int> rangeNumbers)
        {
            for (int i = int.Parse(range[0]); i <= int.Parse(range[1]); i++)
            {
                rangeNumbers.Add(i);
            }
        }
        public static void firstHalf (string[] lines, ref int score)
        {
            foreach (string line in lines)
            {
                HashSet<int> firstRangeNumbers = new HashSet<int>();
                HashSet<int> secondRangeNumbers = new HashSet<int>();
                // Split the lines into two range's
                var splitLines = line.Split(',');
                // Find first range
                Program.getRangeNumbers(splitLines[0].Split('-'), ref firstRangeNumbers);
                Program.getRangeNumbers(splitLines[1].Split('-'), ref secondRangeNumbers);
                if (firstRangeNumbers.IsSubsetOf(secondRangeNumbers) || secondRangeNumbers.IsSubsetOf(firstRangeNumbers))
                {
                    score += 1; 
                }
            }
        }
        public static void secondHalf(string[] lines, ref int score)
        {
            foreach (string line in lines)
            {
                HashSet<int> firstRangeNumbers = new HashSet<int>();
                HashSet<int> secondRangeNumbers = new HashSet<int>();
                // Split the lines into two range's
                var splitLines = line.Split(',');
                // Find first range
                Program.getRangeNumbers(splitLines[0].Split('-'), ref firstRangeNumbers);
                Program.getRangeNumbers(splitLines[1].Split('-'), ref secondRangeNumbers);
                
                HashSet<int> tmp = new HashSet<int>(firstRangeNumbers);
                tmp.IntersectWith(secondRangeNumbers);
                if (tmp.Count() > 0)
                {
                    score += 1;
                }
            }
        }
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllText(@"C:\Users\gtasr\OneDrive\Namizje\code\advent-of-code\Day4CampCleanup\PuzzleInput.txt").Split("\n");
            int score = 0;
            // First half
            Program.firstHalf(lines, ref score);
            Console.WriteLine(score);
            score = 0;
            // Second half
            Program.secondHalf(lines, ref score);
            Console.WriteLine(score);
        }
    }
}