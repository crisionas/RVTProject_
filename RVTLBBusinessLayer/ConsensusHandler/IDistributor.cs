using RVT_Block_lib.Models;
using RVTLBBusinessLayer.Sender;
using RVTLibrary.Objects;
using System.Collections.Generic;

namespace RVTLBBusinessLayer.ConsensusHandler
{
    public interface IDistributor
    {
        public Node Executor { get; set; }
        public void FormateNodeList(int i); // i = numbers of nodes for  choosing
        NodeVoteMessage FormateMessage(ChooserLbMessage message);
    }
}
  