using System;
using System.Windows;
using QuickGraph;

namespace SocialGraph.DesktopClient
{
    class MainViewModel
    {
        public BidirectionalGraph<object, IEdge<object>> CreateGraphToVisualize()
        {
            var g = new BidirectionalGraph<object, IEdge<object>>();

            //add the vertices to the graph
            Vertex[] vertices = new Vertex[5];
            for (int i = 0; i < 5; i++)
            {
                vertices[i] = new Vertex(i.ToString() + " vertice");
                g.AddVertex(vertices[i]);
            }

            //add some edges to the graph
            g.AddEdge(new Edge<object>(vertices[0], vertices[1]));
            g.AddEdge(new Edge<object>(vertices[1], vertices[0]));
            g.AddEdge(new Edge<object>(vertices[2], vertices[3]));
            g.AddEdge(new Edge<object>(vertices[3], vertices[1]));
            g.AddEdge(new Edge<object>(vertices[1], vertices[4]));
            g.AddEdge(new Edge<object>(vertices[1], vertices[2]));

            return g;
        }
    }
}