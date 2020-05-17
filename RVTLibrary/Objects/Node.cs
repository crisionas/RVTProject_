using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace RVTLibrary.Objects
{
    public class Node
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public string NodeId { get; set; }
        [DataMember]
        public string SoftwareVersion { get; set; }


        public string Serialize()
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(Node));
            using (var ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, this);
                var result = Encoding.UTF8.GetString(ms.ToArray());
                return result;
            }
        }

        public static Node Deserialize(string json)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(Node));

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {

                var result = (Node)jsonSerializer.ReadObject(ms);
                return result;

            }
        }

    }
}
