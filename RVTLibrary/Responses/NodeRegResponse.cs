using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace RVT_Block_lib.Responses
{
    public class NodeRegResponse
    {
        /// <summary>
        /// Raspunsul unui nod catre LoadBalancer
        /// </summary> 
        public string IDVN { get; set; }
        public string VnPassword { get; set; }
        public string IDNP { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }

        public string Serialize()
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(NodeRegResponse));
            using (var ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, this);
                var result = Encoding.UTF8.GetString(ms.ToArray());
                return result;
            }
        }


        public static NodeRegResponse Deserialize(string json)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(NodeRegResponse));

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {

                var result = (NodeRegResponse)jsonSerializer.ReadObject(ms);
                return result;
            }
        }
    }
}
