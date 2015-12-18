using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"D:\Dropbox\Projects\C#\AdventOfCode\Day5\input5day.txt");
            int numOfNiceWords = 0;
            //regex for aeiou  ^.*[aeiou].*[aeiou].*[aeiou].*$
            //regex for double letter (.)\1
            //regex not match ab|cd|pq|xy
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (Regex.IsMatch(line, @"^.*[aeiou].*[aeiou].*[aeiou].*$") &&
                    Regex.IsMatch(line, @"(.)\1") &&
                         !Regex.IsMatch(line, "ab|cd|pq|xy"))
                {
                    numOfNiceWords++;
                }
            }
            reader.Close();
            Console.WriteLine("(1part)Num of nice words: " + numOfNiceWords);
            numOfNiceWords = 0;

            //read from begining again
            reader = new StreamReader(@"D:\Dropbox\Projects\C#\AdventOfCode\Day5\input5day.txt");

            //(..).*\1 regex chech for a pair of any two letters that appears at least twice in the string without overlapping
            //(.).\1 regex check for "xyx" and sth like that
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (Regex.IsMatch(line, @"(..).*\1") &&
                    Regex.IsMatch(line, @"(.).\1"))
                {
                    numOfNiceWords++;
                }
            }
            reader.Close();
            Console.WriteLine("(2part)Num of nice words: " + numOfNiceWords);
        }
    }
}
