using Newtonsoft.Json;
using RVT_Block_lib.Models;
using RVT_Block_lib.Responses;
using RVTLBBusinessLayer.ConsensusHandler;
using RVTLBBusinessLayer.Entities;
using RVTLBBusinessLayer.Sender;
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

            var distribuitor = new Distributor(new VoteSender());
            distribuitor.FormateNodeList(3);
            var message = distribuitor.FormateMessage(chooser);

            var response = await distribuitor.Send(distribuitor.Executor, message);

            try
            {
                
                var voteresponse = JsonConvert.DeserializeObject<NodeVoteResponse>(response);
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
