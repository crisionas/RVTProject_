using Newtonsoft.Json;
using RVT_Block_lib.Models;
using RVTLibrary.Objects;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RVTLBBusinessLayer.Sender
{
    public class VoteSender : ISender
    {
        public readonly HttpClient client;
        public string Send(Node node, object package)
        {
            var data_req = JsonConvert.SerializeObject((NodeVoteMessage)package);
            var content = new StringContent(data_req, Encoding.UTF8, "application/json");
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
                AllowAutoRedirect = true
            };

            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(node.Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsync("api/Vote", content);

            return response.Result.Content.ReadAsStringAsync().Result;
        }
    }
}
