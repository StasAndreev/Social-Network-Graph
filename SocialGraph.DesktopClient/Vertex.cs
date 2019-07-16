using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SocialGraph.DesktopClient
{
    [DebuggerDisplay("{ID}")]
    public class Vertex
    {
        public string ID { get; private set; }

        public Vertex(string id) => ID = id;

        public override string ToString() => ID.ToString();

        public Command SimpleCommand
        {
            get { return new Command(() => MessageBox.Show(ID)); }
        }
    }
}