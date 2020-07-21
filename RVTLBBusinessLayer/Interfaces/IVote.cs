using RVT_Block_lib.Models;
using RVT_Block_lib.Responses;
using System.Threading.Tasks;

namespace RVTLBBusinessLayer.Interfaces
{
    public interface IVote
    {
        public Task<VoteLbResponse> Vote(ChooserLbMessage chooser);
    }
}
