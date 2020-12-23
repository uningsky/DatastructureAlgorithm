using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace 그래프2
{
    public class Edge<TVertex>
    {
        public TVertex Source { get; set; }
        public TVertex Destination { get; set; }
        public int Weight { get; set; }

        public Edge(TVertex source, TVertex destination, int weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight; 
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("\tSource: {0} \n\tDestination: {1} \n\tWeight: {2}", Source, Destination, Weight); 

            return builder.ToString(); 
        }
    }
}
