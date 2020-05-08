using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RVT_Block_lib.Responses;
using RVTLBBusinessLayer;
using RVTLBBusinessLayer.Entities;
using RVTLBBusinessLayer.Interfaces;
using RVTLibrary.Models;

namespace RVTLoadBalancer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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