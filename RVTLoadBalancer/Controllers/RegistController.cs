using Microsoft.AspNetCore.Mvc;
using RVT_Block_lib.Responses;
using RVTLBBusinessLayer;
using RVTLBBusinessLayer.Interfaces;
using RVTLibrary.Models;
using System.Threading.Tasks;

namespace RVTLoadBalancer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RegistController : ControllerBase
    {
        public IAdministrator _admin;
        public RegistController()
        {
            var bl = new BusinessManager();
            _admin = bl.GetAdministrator();
        }



        // POST: api/Regist
        [HttpPost]
        public async Task<ActionResult<RegLbResponse>> Register([FromBody] RegistrationMessage message)
        {
            var status = await _admin.Registration(message);
            return status;
        }


    }
}