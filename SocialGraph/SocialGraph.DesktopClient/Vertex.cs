using System.Diagnostics;

namespace SocialGraph.DesktopClient
{
    [DebuggerDisplay("{Id}")]
    public class Vertex
    {
        public System.Guid Id { get; private set; }

        public Vertex(System.Guid Id) => this.Id = Id;

        public override string ToString() => Id.ToString();
    }
}