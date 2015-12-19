using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class GraphVertex
    {
        public string Name { get; set; }
        public List<GraphEdge> Edges { get; set; } = new List<GraphEdge>();

        public GraphVertex(string name)
        {
            Name = name;
        }

        public void AddEdge(GraphVertex vertex, int distance)
        {
            Edges.Add(new GraphEdge(vertex, distance));
        }
    }
}
