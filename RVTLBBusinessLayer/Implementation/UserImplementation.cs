
using RVT_Block_lib.Models;
using RVT_Block_lib.Responses;
using RVTLBBusinessLayer.Entities;
using RVTLibrary.Models;
using RVTLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RVTLBBusinessLayer.Implementation
{
    public class UserImplementation
    {
        internal async Task<RegLbResponse> Registration(RegistrationMessage message)
        {
            var task = new NodeRegMessage();
            task.Message = message;


            NodeList nodelist = NodeList.GetInstance();
            List<Node> list = nodelist.GetList();  // List of all nodes

            Random random = new Random();
            var point = random.Next(list.Count); // Get Random Nod to do task


            IEnumerable<Node> threeRandom = list.OrderBy(x => random.Next()).Take(3).Distinct().Where(m => m.NodeId != list[point].NodeId);

            List<int> neighboors = new List<int>();

            task.NeighBours.Add(list[neighboors[0]]);
            task.NeighBours.Add(list[neighboors[1]]);
            task.NeighBours.Add(list[neighboors[2]]);

            var content = new StringContent(task.Serialize(), Encoding.UTF8, "application.json");
            var handler = new HttpClientHandler();
            //handler.ClientCertificates.Add(cert);
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            handler.AllowAutoRedirect = true;
            var client = new HttpClient(handler);

            client.BaseAddress = new Uri(list[point].IP.ToString());

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsync("api/Register", content);

            var responseFromNode = new NodeRegResponse();
            try
            {

                var data_resp = await response.Result.Content.ReadAsStringAsync();
                responseFromNode = NodeRegResponse.Deserialize(data_resp);
                var datatype = JsonDocument.Parse(data_resp);


            }
            catch (AggregateException e)
            {
                return new RegLbResponse { Status = false, Message = "Eroare de connectare la server LB:" + e.InnerException.ToString() ,ProcessedTime=DateTime.Now};
            }

            return new RegLbResponse
            {
                Status = responseFromNode.Status,
                Message = responseFromNode.Message,
                IDVN = responseFromNode.IDVN,
                VnPassword = responseFromNode.VnPassword,
                ProcessedTime = DateTime.Now
            };

           }




    }
}
