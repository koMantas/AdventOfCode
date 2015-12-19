using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day7
{
    public delegate int WireValue(Wire first, Wire second);
    public class Wire
    {
        public int Value {get; set;}
    }
    class Program
    {
        public static Dictionary<string, Wire> wires = new Dictionary<string, Wire>();

        static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            StreamReader reader = new StreamReader(@"D:\Dropbox\Projects\C#\AdventOfCode\Day7\input7day.txt");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (Regex.IsMatch(line, @"^\d+ -> \w+$"))
                {
                    string[] data = line.Split(' ');
                    Wire temp = CheckExistance(data[2]);
                    temp.Value = int.Parse(data[0]);
                }
                else
                {
                    lines.Add(line);
                }
            }
            reader.Close();

            while(lines.Count > 0)
            {
                for(int i=0;i<lines.Count;i++)
                {
                    string line = lines[i];
                    string[] data = line.Split(' ');
                    // -> operation
                    if (data.Length == 3)
                    {
                        if (wires.ContainsKey(data[0]))
                        {
                            Wire receiver = CheckExistance(data[2]);
                            Wire producer = wires[data[0]];
                            receiver.Value = producer.Value;
                            lines.RemoveAt(i);
                            i--;
                        }
                    }
                    //NOT operation
                    else if (data.Length == 4)
                    {
                        if (wires.ContainsKey(data[1]))
                        {
                            Wire producer = wires[data[1]];
                            Wire receiver = CheckExistance(data[3]);
                            receiver.Value = ~producer.Value;
                            lines.RemoveAt(i);
                            i--;
                        }
                    }
                    else
                    {
                        switch (data[1])
                        {
                            case ("LSHIFT"):
                                if (wires.ContainsKey(data[0]))
                                {
                                    Wire producer = wires[data[0]];
                                    Wire receiver = CheckExistance(data[4]);
                                    receiver.Value = producer.Value << int.Parse(data[2]);
                                    lines.RemoveAt(i);
                                    i--;
                                }
                                break;
                            case ("RSHIFT"):
                                if (wires.ContainsKey(data[0]))
                                {
                                    Wire producer = wires[data[0]];
                                    Wire receiver = CheckExistance(data[4]);
                                    receiver.Value = producer.Value >> int.Parse(data[2]);
                                    lines.RemoveAt(i);
                                    i--;
                                }
                                break;
                            case ("AND"):
                                {
                                    int signal1;
                                    int signal2;
                                    if (int.TryParse(data[0], out signal1))
                                    {
                                        if (int.TryParse(data[2], out signal2))
                                        {
                                            Wire temp = CheckExistance(data[4]);
                                            temp.Value = signal1 & signal2;
                                            lines.RemoveAt(i);
                                            i--;
                                        }
                                        else
                                        {
                                            if (wires.ContainsKey(data[2]))
                                            {
                                                Wire provider = wires[data[2]];
                                                Wire receiver = CheckExistance(data[4]);
                                                receiver.Value = provider.Value & signal1;
                                                lines.RemoveAt(i);
                                                i--;
                                            }
                                        }
                                    }
                                    else if (int.TryParse(data[2], out signal2))
                                    {
                                        if (wires.ContainsKey(data[0]))
                                        {
                                            Wire provider = wires[data[0]];
                                            Wire receiver = CheckExistance(data[4]);
                                            receiver.Value = provider.Value & signal2;
                                            lines.RemoveAt(i);
                                            i--;
                                        }
                                    }
                                    else
                                    {
                                        if (wires.ContainsKey(data[0]) && wires.ContainsKey(data[2]))
                                        {
                                            Wire provider1 = wires[data[0]];
                                            Wire provider2 = wires[data[2]];
                                            Wire receiver = CheckExistance(data[4]);
                                            receiver.Value = provider1.Value & provider2.Value;
                                            lines.RemoveAt(i);
                                            i--;
                                        }
                                    }
                                }
                                break;
                            case ("OR"):
                                {
                                    int signal1;
                                    int signal2;
                                    if (int.TryParse(data[0], out signal1))
                                    {
                                        if (int.TryParse(data[2], out signal2))
                                        {
                                            Wire temp = CheckExistance(data[4]);
                                            temp.Value = signal1 | signal2;
                                            lines.RemoveAt(i);
                                            i--;
                                        }
                                        else
                                        {
                                            if (wires.ContainsKey(data[2]))
                                            {
                                                Wire provider = wires[data[2]];
                                                Wire receiver = CheckExistance(data[4]);
                                                receiver.Value = provider.Value | signal1;
                                                lines.RemoveAt(i);
                                                i--;
                                            }
                                        }
                                    }
                                    else if (int.TryParse(data[2], out signal2))
                                    {
                                        if (wires.ContainsKey(data[0]))
                                        {
                                            Wire provider = wires[data[0]];
                                            Wire receiver = CheckExistance(data[4]);
                                            receiver.Value = provider.Value | signal2;
                                            lines.RemoveAt(i);
                                            i--;
                                        }
                                    }
                                    else
                                    {
                                        if (wires.ContainsKey(data[0]) && wires.ContainsKey(data[2]))
                                        {
                                            Wire provider1 = wires[data[0]];
                                            Wire provider2 = wires[data[2]];
                                            Wire receiver = CheckExistance(data[4]);
                                            receiver.Value = provider1.Value | provider2.Value;
                                            lines.RemoveAt(i);
                                            i--;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    }
                }


            Console.WriteLine("a signal value:"+wires["a"].Value);
        }

        private static Wire CheckExistance(string name)
        {
            if (wires.ContainsKey(name))
            {
                return wires[name];
            }
            else
            {
                Wire temp = new Wire();
                wires.Add(name, temp);
                return temp;
            }
        }
       
    }
}
