using RVTLBBusinessLayer.Entities;
using RVTLBBusinessLayer.Interfaces;

namespace RVTLBBusinessLayer
{
    public class BusinessManager
    {
        public IAdministrator GetAdministrator()
        {
            return new Regist();
        }
        public IVote GetVote()
        {
            return new Vote();
        }
    }
}
