using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "vzbxkghb";
            //if requirements are fulfilled then requirements variable become false
            while (true)
            {
                input = GetNextPassword(input);
                if (CheckRequirements(input))
                    break;
            }
            Console.WriteLine("New password: "+ input);
            while (true)
            {
                input = GetNextPassword(input);
                if (CheckRequirements(input))
                    break;
            }
            Console.WriteLine("New password: " + input);
        }

        static bool CheckRequirements(string input)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            if (!Regex.IsMatch(input, @"i|o|l"))
            {
                bool isIncreasing = false;
                bool twoPairs = false;
                int numOfPairs = 0;
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    //check for abc and etc.
                    if (i < (inputBytes.Length - 2) && !isIncreasing)
                    {
                        if (inputBytes[i] + 1 == inputBytes[i + 1] &&
                            inputBytes[i + 1] + 1 == inputBytes[i + 2])
                        {
                            isIncreasing = true;
                        }
                    }
                    //check for pairs
                    if (i < inputBytes.Length - 1 && !twoPairs)
                    {
                        if (inputBytes[i] == inputBytes[i + 1])
                        {
                            //acept xxx not twice but once
                            if (i + 2 != inputBytes.Length && inputBytes[i + 1] != inputBytes[i + 2])
                                numOfPairs++;
                            //if it is end it doesnt require to check i+2 element because it doesnt exist
                            else if (i + 1 == inputBytes.Length - 1)
                                numOfPairs++;
                        }
                        if(numOfPairs == 2)
                        {
                            twoPairs = true;
                        }
                    }

                }
                if (twoPairs && isIncreasing)
                    return true;
            }
            return false;
        }

        static string GetNextPassword(string input)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            int i = inputBytes.Length - 1;
            while (true)
            {
                if ((inputBytes[i] + 1) == 123)
                {
                    inputBytes[i] = 97;
                    i--;
                    if (i == -1)
                    {
                        break;
                    }
                }
                else
                {
                    inputBytes[i] += 1;
                    break;
                }
            }
            return Encoding.ASCII.GetString(inputBytes);
        }
    }
}
