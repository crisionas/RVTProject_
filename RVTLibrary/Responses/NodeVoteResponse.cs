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
        public string Serialize()
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(NodeVoteResponse));
            using (var ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, this);
                var result = Encoding.UTF8.GetString(ms.ToArray());
                return result;
            }
        }


        public static NodeVoteResponse Deserialize(string json)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(NodeVoteResponse));

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {

                var result = (NodeVoteResponse)jsonSerializer.ReadObject(ms);
                return result;
            }
        }
    }
}
