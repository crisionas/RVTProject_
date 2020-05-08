using RVT_Block_lib.Models;
using RVT_Block_lib.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RVTLBBusinessLayer.Interfaces
{
    public interface IVote
    {
        public Task<VoteLbResponse> Vote(ChooserLbMessage chooser);
    }
}
