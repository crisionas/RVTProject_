using RVT_Block_lib.Models;
using RVT_Block_lib.Responses;
using RVTLBBusinessLayer.Entities;
using RVTLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
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
            voteMessage.NeighBours = list;

            var content = new StringContent(voteMessage.Serialize(), Encoding.UTF8, "application.json");
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            handler.AllowAutoRedirect = true;
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:44383/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));
            var response = client.PostAsync("api/Register", content);
            var voteresponse = new NodeVoteResponse();

            try
            {
                var resp = await response.Result.Content.ReadAsStringAsync();
                voteresponse = NodeVoteResponse.Deserialize(resp);
                var datatype = JsonDocument.Parse(resp) ;

            }
            catch(AggregateException ex)
            {
                return new VoteLbResponse { Status = false, Message = "Eroare de conectare la server LB:" + ex.InnerException.ToString(), ProcessedTime = DateTime.Now };
            }
            return new VoteLbResponse
            {
                Status = voteresponse.Status,
                Block = voteresponse.Block,
                Message = voteresponse.Message,
                ProcessedTime = voteresponse.ProcessedTime
            };

        }
    }
}
