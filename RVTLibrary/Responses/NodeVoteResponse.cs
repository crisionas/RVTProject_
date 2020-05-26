using RVT_Block_lib.Models;
using RVTLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

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
