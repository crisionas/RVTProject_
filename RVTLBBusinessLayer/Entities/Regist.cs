using RVT_Block_lib.Responses;
using RVTLBBusinessLayer.Implementation;
using RVTLBBusinessLayer.Interfaces;
using RVTLibrary.Models;
using System.Threading.Tasks;

namespace RVTLBBusinessLayer.Entities
{
    public class Regist : UserImplementation, IAdministrator
    {
        public Task<RegLbResponse> Registration(RegistrationMessage message)
        {
            return RegistrationAction(message);
        }

    }
}
