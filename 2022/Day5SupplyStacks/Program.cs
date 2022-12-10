using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Day5
{
    internal class Program
    {
        static Stack<char> one = new Stack<char>();
        static Stack<char> two = new Stack<char>();
        static Stack<char> three = new Stack<char>();
        static Stack<char> four = new Stack<char>();
        static Stack<char> five = new Stack<char>();
        static Stack<char> six = new Stack<char>();
        static Stack<char> seven = new Stack<char>();
        static Stack<char> eight = new Stack<char>();
        static Stack<char> nine = new Stack<char>();
        static void FirstHalf(string[] lines, ref Dictionary<string, Stack<char>> stacks)
        {
            for (int i = 10; i < lines.Length; i++)
            {
                string line = lines[i];
                var tmp = line.Split(' ');
                int numberOfItems = int.Parse(tmp[1]);
                for (int j = 0; j < numberOfItems; j++)
                {
                    stacks[tmp[5]].Push(stacks[tmp[3]].Pop());
                }
            }
        }
        static void SecondHalf(string[] lines, ref Dictionary<string, Stack<char>> stacks)
        {
            for (int i = 10; i < lines.Length; i++)
            {
                string line = lines[i];
                var tmp = line.Split(' ');
                int numberOfItems = int.Parse(tmp[1]);
                Stack<char> reverse = new Stack<char>();
                if (numberOfItems == 1)
                {
                    stacks[tmp[5]].Push(stacks[tmp[3]].Pop());
                }
                else
                {
                    for (int j = 0; j < numberOfItems; j++)
                    {
                        reverse.Push(stacks[tmp[3]].Pop());
                    }
                    reverse.Reverse();
                    foreach (char c in reverse)
                    {
                        stacks[tmp[5]].Push(c);
                    }
                }

            }
        }
        public static Dictionary<string, Stack<char>> initMainStack()
        {
            Program.one.Push('B'); Program.one.Push('W'); Program.one.Push('N');
            Program.two.Push('L'); Program.two.Push('Z'); Program.two.Push('S'); Program.two.Push('P'); Program.two.Push('T'); Program.two.Push('D'); Program.two.Push('M'); Program.two.Push('B');
            Program.three.Push('Q'); Program.three.Push('H'); Program.three.Push('Z'); Program.three.Push('W'); Program.three.Push('R');
            Program.four.Push('W'); Program.four.Push('D'); Program.four.Push('V'); Program.four.Push('J'); Program.four.Push('Z'); Program.four.Push('R');
            Program.five.Push('S'); Program.five.Push('H'); Program.five.Push('M'); Program.five.Push('B');
            Program.six.Push('L'); Program.six.Push('G'); Program.six.Push('N'); Program.six.Push('J'); Program.six.Push('H'); Program.six.Push('V'); Program.six.Push('P'); Program.six.Push('B');
            Program.seven.Push('J'); Program.seven.Push('Q'); Program.seven.Push('Z'); Program.seven.Push('F'); Program.seven.Push('H'); Program.seven.Push('D'); Program.seven.Push('L'); Program.seven.Push('S');
            Program.eight.Push('W'); Program.eight.Push('S'); Program.eight.Push('F'); Program.eight.Push('J'); Program.eight.Push('G'); Program.eight.Push('Q'); Program.eight.Push('B');
            Program.nine.Push('Z'); Program.nine.Push('W'); Program.nine.Push('M'); Program.nine.Push('S'); Program.nine.Push('C'); Program.nine.Push('D'); Program.nine.Push('J');
            Dictionary<string, Stack<char>> stacks = new Dictionary<string, Stack<char>>();
            stacks.Add("1", Program.one); stacks.Add("2", Program.two); stacks.Add("3", Program.three); stacks.Add("4", Program.four); stacks.Add("5", Program.five); stacks.Add("6", Program.six); stacks.Add("7", Program.seven); stacks.Add("8", Program.eight); stacks.Add("9", Program.nine);
            return stacks;
        }
        static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();
            string[] lines = System.IO.File.ReadAllText(@"C:\Users\gtasr\OneDrive\Namizje\code\advent-of-code\Day5SupplyStacks\PuzzleInput.txt").Split("\n");
           
            Dictionary<string, Stack<char>> stacks = Program.initMainStack();
            // First half
            Program.FirstHalf(lines, ref stacks);
            foreach (KeyValuePair<string, Stack<char>> stack in stacks)
            {
                Console.Write(stack.Value.Peek());
            }
            Console.WriteLine("");
            Dictionary<string, Stack<char>> stacks2 = Program.initMainStack();
            // Second half
            Program.SecondHalf(lines, ref stacks2);
            foreach (KeyValuePair<string, Stack<char>> stack in stacks2)
            {
                Console.Write(stack.Value.Peek());
            }
            Console.WriteLine("");
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: " + stopwatch.Elapsed);
        }
    }
}
