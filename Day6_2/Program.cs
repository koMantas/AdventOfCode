using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6_2
{
    public class Light
    {
        private int _brightness;
        public int Brightness
        {
            get
            {
                return _brightness;
            }
            set
            {
                if (value >= 0)
                    _brightness = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"D:\Dropbox\Projects\C#\AdventOfCode\Day6\inputday6.txt");

            Light[,] lights = new Light[1000, 1000];

            for (int i = 0; i <= 999; i++)
            {
                for (int j = 0; j <= 999; j++)
                {
                    lights[i, j] = new Light();
                }
            }


            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(' ');
                string[] firstCoordinates;
                string[] secondCoordinates;
                switch (data[0])
                {
                    case ("turn"):
                        firstCoordinates = data[2].Split(',');
                        secondCoordinates = data[4].Split(',');
                        if (string.Equals(data[1], "on"))
                            TurnOnLights(lights,
                                int.Parse(firstCoordinates[0]),
                                int.Parse(firstCoordinates[1]),
                                int.Parse(secondCoordinates[0]),
                                int.Parse(secondCoordinates[1]));
                        else
                            TurnOffLights(lights,
                                int.Parse(firstCoordinates[0]),
                                int.Parse(firstCoordinates[1]),
                                int.Parse(secondCoordinates[0]),
                                int.Parse(secondCoordinates[1]));
                        break;
                    case ("toggle"):
                        firstCoordinates = data[1].Split(',');
                        secondCoordinates = data[3].Split(',');
                        ToggleLights(lights,
                                int.Parse(firstCoordinates[0]),
                                int.Parse(firstCoordinates[1]),
                                int.Parse(secondCoordinates[0]),
                                int.Parse(secondCoordinates[1]));
                        break;
                }
            }

            int numOfBrightness = 0;
            for (int i = 0; i <= 999; i++)
            {
                for (int j = 0; j <= 999; j++)
                {
                    numOfBrightness += lights[i, j].Brightness;
                }
            }

            Console.WriteLine("Number of brightness: " + numOfBrightness);
        }

        private static void ToggleLights(Light[,] lights, int x1, int y1, int x2, int y2)
        {
            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    lights[i, j].Brightness += 2;
                }
            }
        }

        private static void TurnOffLights(Light[,] lights, int x1, int y1, int x2, int y2)
        {
            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    lights[i, j].Brightness--;
                }
            }
        }

        private static void TurnOnLights(Light[,] lights, int x1, int y1, int x2, int y2)
        {
            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    lights[i, j].Brightness++;
                }
            }
        }
    }
}
