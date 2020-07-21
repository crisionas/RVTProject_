using Microsoft.AspNetCore.Mvc;
using RVT_Block_lib.Models;
using RVT_Block_lib.Responses;
using RVTLBBusinessLayer;
using RVTLBBusinessLayer.Interfaces;
using System.Threading.Tasks;

namespace RVTLoadBalancer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        public IVote _vote;
        public VoteController()
        {
            var bl = new BusinessManager();
            _vote = bl.GetVote();
        }



        // POST: api/Vote
        [HttpPost]
        public async Task<ActionResult<VoteLbResponse>> Vote([FromBody] ChooserLbMessage message)
        {
            var status = await _vote.Vote(message);
            return status;
        }
    }
}