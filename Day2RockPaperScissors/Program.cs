using System;

namespace RockPaperScissors
{
    internal class Program
    {
        static void FirstPart(string[] lines, ref int score)
        {
            // Opponent A - Rock, B - Paper, C - Scissors
            // Me X - Rock, Y - Paper, Z - Scissors
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                string opponent = parts[0];
                string me = parts[1];
                // Check what i play and then add the apropriate scores
                switch (me)
                {
                    case "X":
                        score += 1;
                        break;
                    case "Y":
                        score += 2;
                        break;
                    case "Z":
                        score += 3;
                        break;
                }
                // Check if i won
                if (me == "X" && opponent == "C" || me == "Y" && opponent == "A" || me == "Z" && opponent == "B") {
                    score += 6;
                } else if (me == "X" && opponent == "A" || me == "Y" && opponent == "B" || me == "Z" && opponent == "C") {
                    score += 3;
                }
            }
        }
        static void SecondPart(string[] lines, ref int score)
        {
            // Opponent A - Rock, B - Paper, C - Scissors
            // Me X - Win, Y - Draw, Z - Lose
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                string opponent = parts[0];
                string me = parts[1];
                // Check what i play and then add the apropriate scores
                switch (me)
                {
                    case "X":
                        if (opponent == "A") {
                            score += 3;
                        } else if (opponent == "B") {
                            score += 1;
                        } else if (opponent == "C") {
                            score += 2;
                        }
                        break;
                    case "Y":
                        score += 3;
                        if (opponent == "A") {
                            score += 1;
                        } else if (opponent == "B") {
                            score += 2;
                        } else if (opponent == "C") {
                            score += 3;
                        }
                        break;
                    case "Z":
                        score += 6;
                        if (opponent == "A") {
                            score += 2;
                        } else if (opponent == "B") {
                            score += 3;
                        } else if (opponent == "C") {
                            score += 1;
                        }
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllText(@"C:\Users\gtasr\OneDrive\Namizje\code\advent-of-code\Day2RockPaperScissors\PuzzleInput.txt").Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            int score1 = 0;
            int score2 = 0;
            // Part 1
            Program.FirstPart(lines, ref score1);
            Console.WriteLine(score1);
            // Part 2
            Program.SecondPart(lines, ref score2);
            Console.WriteLine(score2);
        }
    }
}