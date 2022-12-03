namespace Day3
{
    internal class Program
    {
        static void checkCharPriority(char letter, ref int priority)
        {
            if (char.IsUpper(letter))
            {
                priority += (int)letter - 38;
            }
            else
            {
                priority += (int)letter - 96;
            }
        }
        static void addLettersToElfList(ref List<char> elfList, string line)
        {
            foreach (char c in line)
            {
                elfList.Add(c);
            }
        }
        static void firstHalf(string[] lines, ref int priority)
        {
            foreach (string line in lines)
            {
                List<char> firstHalf = new List<char>();
                List<char> secondHalf = new List<char>();
                for (var i = 0; i < line.Length / 2; i++)
                {
                    firstHalf.Add(line[i]);
                }
                for (var i = line.Length / 2; i < line.Length; i++)
                {
                    secondHalf.Add(line[i]);
                }
                var commonList = firstHalf.Select(f => f).ToList().Intersect(secondHalf.Select(s => s).ToList()).ToList();
                foreach (char letter in commonList)
                {
                    Program.checkCharPriority(letter, ref priority);
                }
            }
        }
        static void secondHalf(string[] lines, ref int priority)
        {
            int current = 0;
            List<char> firstElf = new List<char>();
            List<char> secondElf = new List<char>();
            List<char> thirdElf = new List<char>();
            foreach (string line in lines)
            {
                current++;
                if (current > 3)
                {
                    current = 1;
                    firstElf = new List<char>();
                    secondElf = new List<char>();
                    thirdElf = new List<char>();
                }
                if (current == 1) {
                    Program.addLettersToElfList(ref firstElf, line);
                } else if (current == 2) {
                    Program.addLettersToElfList(ref secondElf, line);
                } else {
                    Program.addLettersToElfList(ref thirdElf, line);
                }
                if (current == 3) {
                    var tmp = firstElf.Select(f => f).ToList().Intersect(secondElf.Select(s => s).ToList()).ToList();
                    var commonList = tmp.Select(tmp => tmp).ToList().Intersect(thirdElf.Select(t => t).ToList()).ToList();
                    foreach (char letter in commonList)
                    {
                        Program.checkCharPriority(letter, ref priority);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllText(@"C:\Users\gtasr\OneDrive\Namizje\code\advent-of-code\Day3RucksackReorganization\PuzzleInput.txt").Split("\n");
            int priority = 0;

            // Part one
            Program.firstHalf(lines, ref priority);
            Console.WriteLine(priority);
            priority = 0;
            // Part two
            Program.secondHalf(lines, ref priority);
            Console.WriteLine(priority);
        }
    }
}