using RVTLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVT_Block_lib.Responses
{
    public class VoteLbResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public Block Block { get; set; }
        public DateTime ProcessedTime { get; set; }
    }
}
