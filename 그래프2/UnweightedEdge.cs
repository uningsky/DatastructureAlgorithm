using System;
using System.Collections.Generic;
using System.Text;

namespace 그래프2
{
    public class UnweightedEdge<TVertex>
    {
        public TVertex Source { get; set; }
        public TVertex Destination { get; set; }

        public UnweightedEdge(TVertex source, TVertex destination)
        {
            Source = source;
            Destination = destination;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("\tSource: {0} \n\tDestination: {1}", Source, Destination);

            return builder.ToString();
        }
    }
}
