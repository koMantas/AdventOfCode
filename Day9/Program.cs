using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    class Program
    {
        private static Dictionary<string, GraphVertex> _graph = new Dictionary<string, GraphVertex>();

        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"D:\Dropbox\Projects\C#\AdventOfCode\Day9\inputday9.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] data = line.Split(' ');
                    GraphVertex first = GetVertex(data[0]);
                    GraphVertex second = GetVertex(data[2]);
                    int distance = int.Parse(data[4]);
                    first.AddEdge(second, distance);
                    second.AddEdge(first, distance);
                }
            }

            var result = GetPermutations<string>(_graph.Keys, _graph.Count);
            List<List<string>> results = new List<List<string>>();
            foreach(var permutation in result)
            {
                var temp = new List<string>();
                foreach(var item in permutation)
                {
                    temp.Add(item);
                }
                results.Add(temp);
            }
            List<int> distances = new List<int>();
            for (int i = 0; i < results.Count; i++)
            {
                int tempDistance = 0;
                GraphVertex temp = _graph[results[i][0]];
                for(int j = 1; j < results[i].Count; j++)
                {
                    var nextVertex = temp.Edges.Where(e => e.Vertex.Name == results[i][j]).FirstOrDefault();
                    if (nextVertex != null)
                    {
                        tempDistance += nextVertex.Distance;
                        temp = nextVertex.Vertex;
                    }
                    else
                    {
                        tempDistance = -1;
                        break;
                    }
                }
                if(tempDistance != -1)
                    distances.Add(tempDistance);
            }
            distances.Sort();
            Console.WriteLine("Shortest path:"+distances[0]);
            Console.WriteLine("Longest path:" + distances[distances.Count - 1]);
        }

        //copied from stackoverflow http://stackoverflow.com/questions/1952153/whatis-the-best-way-to-find-all-combinations-of-itemsin-an-array/10629938#10629938
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(o => !t.Contains(o)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        private static GraphVertex GetVertex(string name)
        {
            if (_graph.ContainsKey(name))
            {
                return _graph[name];
            }
            else
            {
                GraphVertex temp = new GraphVertex(name);
                _graph.Add(name, temp);
                return temp;
            }
        }
    }
}
