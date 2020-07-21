using RVT_Block_lib.Responses;
using RVTLibrary.Models;
using System.Threading.Tasks;

namespace RVTLBBusinessLayer.Interfaces
{
    public interface IAdministrator
    {
        Task<RegLbResponse> Registration(RegistrationMessage message);
    }
}
