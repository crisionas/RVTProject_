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
        public  Task<RegLbResponse> Registration(RegistrationMessage message)
        {
            return  RegistrationAction(message);
        }

    }
}
