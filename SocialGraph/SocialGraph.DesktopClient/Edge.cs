using System;
using QuickGraph;
using System.Diagnostics;

namespace SocialGraph.DesktopClient.Graph
{
    [DebuggerDisplay("{Source.ID} -> {Target.ID}")]
    public class Edge : Edge<Vertex>
    {
        public string ID { get; private set; }

        public Edge(string id, Vertex source, Vertex target)
            :base(source, target)
        {
            ID = id;
        }
    }
}