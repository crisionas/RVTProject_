
using RVTLibrary.Objects;
using System.Collections.Generic;

namespace RVT_Block_lib.Models
{
    public class NodeVoteMessage
    {
        public ChooserLbMessage message { get; set; }
        public List<Node> NeighBours { get; set; }


    }
}
