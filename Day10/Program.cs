using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            long input = 1113222113;
            List<int> number = NumberToList(input);
            for(int i = 0; i < 40; i++)
            {
                number = GetNextLookAndSay(number);
            }
            Console.WriteLine("After 40 times lenght:"+number.Count);
            number = NumberToList(input);
            for (int i = 0; i < 50; i++)
            {
                number = GetNextLookAndSay(number);
            }
            Console.WriteLine("After 50 times lenght:" + number.Count);
        }

        static List<int> NumberToList(long value)
        {
            List<int> numberDigits = new List<int>();
            while (value != 0)
            {
                int number = (int)value % 10;
                value -= number;
                value /= 10;
                numberDigits.Insert(0, number);
            }
            return numberDigits;
        }

        static List<int> GetNextLookAndSay(List<int> number)
        {
            List<int> nextValue = new List<int>();
            int digit = number[0];
            int countOfDigits = 0;
            for (int i = 0; i < number.Count; i++)
            {
                if(number[i]== digit)
                {
                    countOfDigits++;
                }
                else
                {
                    nextValue.Add(countOfDigits);
                    nextValue.Add(digit);
                    digit = number[i];
                    countOfDigits = 0;
                    countOfDigits++;
                }
            }
            nextValue.Add(countOfDigits);
            nextValue.Add(digit);
            return nextValue;
        }
    }
}
