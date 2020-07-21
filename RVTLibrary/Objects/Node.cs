using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace RVTLibrary.Objects
{
    public class Node
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string NodeId { get; set; }
        public string SoftwareVersion { get; set; }
        public string Thumbprint { get; set; }
        public byte[] PublicKey { get; set; }
    }
}
