using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class GraphEdge
    {
        public GraphVertex Vertex { get; set; }
        public int Distance { get; set; }

        public GraphEdge(GraphVertex vertex, int distance)
        {
            Vertex = vertex;
            Distance = distance;
        }
    }
}
