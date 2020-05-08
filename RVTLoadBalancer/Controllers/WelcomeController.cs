using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RVTLBBusinessLayer;
using RVTLBBusinessLayer.Entities;
using RVTLBBusinessLayer.Interfaces;
using RVTLibrary.Models;
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
            NodeList.GetInstance();
            NodeList.Nodes.Add(node);
        }
    }
}