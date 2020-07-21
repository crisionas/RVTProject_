using RVTLibrary;
using System;

namespace RVT_Block_lib.Responses
{
    public class NodeVoteResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public Block Block { get; set; }
        public DateTime ProcessedTime { get; set; }
    }
}
