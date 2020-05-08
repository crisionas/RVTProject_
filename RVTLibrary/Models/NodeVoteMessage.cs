
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

        public string Serialize()
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(NodeRegMessage));
            using (var ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, this);
                var result = Encoding.UTF8.GetString(ms.ToArray());
                return result;
            }
        }


        public static NodeVoteMessage Deserialize(string json)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(NodeRegMessage));

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {

                var result = (NodeVoteMessage)jsonSerializer.ReadObject(ms);
                return result;
            }
        }

    }
}
