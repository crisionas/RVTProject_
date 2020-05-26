
using RVTLibrary.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace RVT_Block_lib.Models
{
    public class NodeVoteMessage
    {
        public ChooserLbMessage message { get; set; }
        public List<Node> NeighBours { get; set; }


    }
}
