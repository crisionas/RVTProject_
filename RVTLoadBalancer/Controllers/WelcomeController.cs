using Microsoft.AspNetCore.Mvc;
using RVTLBBusinessLayer;
using RVTLBBusinessLayer.Entities;
using RVTLBBusinessLayer.Interfaces;
using RVTLibrary.Objects;

namespace RVTLoadBalancer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        public IAdministrator _admin;
        public WelcomeController()
        {
            var bl = new BusinessManager();
            _admin = bl.GetAdministrator();
        }



        // POST: api/Welcome
        [HttpPost]
        public void Post([FromBody] Node node)
        {
            node.Thumbprint = HttpContext.Connection.ClientCertificate.Thumbprint;
            NodeList.GetInstance();
            NodeList.Nodes.Add(node);
        }
    }
}