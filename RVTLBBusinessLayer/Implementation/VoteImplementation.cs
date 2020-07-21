using Newtonsoft.Json;
using RVT_Block_lib.Models;
using RVT_Block_lib.Responses;
using RVTLBBusinessLayer.Entities;
using RVTLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RVTLBBusinessLayer.Implementation
{
    public class VoteImplementation
    {
        internal async Task<VoteLbResponse> VoteAction(ChooserLbMessage chooser)
        {
            var voteMessage = new NodeVoteMessage();
            voteMessage.message = chooser;
            NodeList nodeList = NodeList.GetInstance();
            List<Node> list = nodeList.GetList();
            // voteMessage.NeighBours = list;


            Random random = new Random();
            var point = random.Next(list.Count);
            IEnumerable<Node> threeRandom = list.OrderBy(x => random.Next()).Where(m => m.NodeId != list[point].NodeId).Take(3).Distinct();

            List<Node> neighboors = new List<Node>();
            foreach (var item in threeRandom)
            {
                neighboors.Add(item);
            }

            voteMessage.NeighBours = neighboors;
            var data_req = JsonConvert.SerializeObject(voteMessage);
            var content = new StringContent(data_req, Encoding.UTF8, "application/json");
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            handler.AllowAutoRedirect = true;
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(list[point].Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));
            var response = client.PostAsync("api/Vote", content);
            var voteresponse = new NodeVoteResponse();

            try
            {
                var resp = await response.Result.Content.ReadAsStringAsync();
                voteresponse = JsonConvert.DeserializeObject<NodeVoteResponse>(resp);
                return new VoteLbResponse
                {
                    Status = voteresponse.Status,
                    Block = voteresponse.Block,
                    Message = voteresponse.Message,
                    ProcessedTime = voteresponse.ProcessedTime
                };
            }
            catch (AggregateException ex)
            {
                return new VoteLbResponse { Status = false, Message = "Eroare de conectare la server LB:" + ex.InnerException.ToString(), ProcessedTime = DateTime.Now };
            }

        }
    }
}
