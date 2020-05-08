using RVT_Block_lib.Responses;
using RVTLBBusinessLayer.Entities;
using RVTLibrary.Models;
using RVTLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RVTLBBusinessLayer.Interfaces
{
    public interface IAdministrator
    {
        public Task<RegLbResponse> Registration(RegistrationMessage message);
    }
}
