using RVT_Block_lib.Responses;
using RVTLBBusinessLayer.Implementation;
using RVTLBBusinessLayer.Interfaces;
using RVTLibrary.Models;
using RVTLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RVTLBBusinessLayer.Entities
{
    public class Regist : UserImplementation, IAdministrator
    {
        public new async Task<RegLbResponse> Registration(RegistrationMessage message)
        {
            return await Registration(message);
        }

    }
}
