using RVTLibrary.Algoritms;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace RVTLibrary
{
    public static class Helpers
    {
        public static object DataContract { get; private set; }

        public static string GetJson(this IHashable component)
        {
            var jsonFormatter = new DataContractJsonSerializer(component.GetType());
            using (var ms = new MemoryStream())
            {
                jsonFormatter.WriteObject(ms, component);
                var jsonString = Encoding.UTF8.GetString((ms.ToArray()));
                return jsonString;
            }
        }
        public static IHashable Deserialize(Type type, string json)
        {
            var jsonFormatter = new DataContractJsonSerializer(type);
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var deserialize = new DataContractJsonSerializer(type);
                var result = (IHashable)deserialize.ReadObject(ms);
                return result;
            }
        }
        public static bool IsCorrect(this IHashable component, IAlgorithm algorithm = null)
        {
            if (algorithm == null)
            {
                algorithm = AlgorithmHelper.GetDefaultAlgorithm();
            }

            var correct = component.Hash == component.GetHash(algorithm);
            return correct;
        }
    }
}
