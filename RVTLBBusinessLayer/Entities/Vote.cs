using RVT_Block_lib.Models;
using RVT_Block_lib.Responses;
using RVTLBBusinessLayer.Implementation;
using RVTLBBusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RVTLBBusinessLayer.Entities
{
    public class Vote : VoteImplementation, IVote
    {
        async Task<VoteLbResponse> IVote.Vote(ChooserLbMessage chooser)
        {
            return await VoteAction(chooser);
        }
    }
}
