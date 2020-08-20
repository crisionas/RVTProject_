using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RVTLBBusinessLayer;
using RVTLBBusinessLayer.Interfaces;
using RVTLibrary.Objects;

namespace RVTLoadBalancer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IAdmin _admin;
        public AdminController()
        {
            var bl = new BusinessManager();
            _admin = bl.GetAdmin();
        }
        [HttpGet]
        public async Task<List<Node>> NodesAction()
        {
            var nodes = await _admin.Nodes();
            return nodes;
        }
    }
}
