using System;


namespace CalorieCounting // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllText(@"C:\Users\gtasr\OneDrive\Namizje\code\advent-of-code\Day1CalorieCounting\PuzzleInput.txt").Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            List<int> calories = new List<int>();
            int current = 0;
            foreach (string line in lines)
            {
                if (line == "")
                {
                    calories.Add(current);
                    current = 0;
                    continue;
                }
                current += Int32.Parse(line);
            }
            calories.Sort(); 

            Console.WriteLine("Second solution: " + calories.Skip(calories.Max(0, calories.Count() - 3)).Sum());
        }
    }
}
