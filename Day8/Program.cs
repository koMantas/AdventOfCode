using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"D:\Dropbox\Projects\C#\AdventOfCode\Day8\inputday8.txt");
            int sizeInCode = 0;
            int sizeInMemory = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                byte[] linebyte = Encoding.ASCII.GetBytes(line);
                sizeInCode += linebyte.Length;
                line = line.Remove(0, 1);
                line = line.Remove(line.Length - 1, 1);
                line = line.Replace("\\\"", "1");
                line = line.Replace("\\\\", "2");
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '\\')
                    {
                        if (line[i + 1] == 'x')
                        {
                            line = line.Remove(i, 3);
                        }
                    }
                }
                sizeInMemory += line.Length;
            }
            Console.WriteLine(sizeInCode - sizeInMemory);
            reader.Close();
            //second part
            reader = new StreamReader(@"D:\Dropbox\Projects\C#\AdventOfCode\Day8\inputday8.txt");
            int sizeOfEncodendString = 0;
            int sizeOfOriginalString = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                sizeOfOriginalString += line.Length;
                line = line.Replace("\\", "\\\\");
                line = line.Replace("\"", "\\\"");
                sizeOfEncodendString += line.Length + 2;
            }
            reader.Close();
            Console.WriteLine(sizeOfEncodendString - sizeOfOriginalString);

        }
    }
}
