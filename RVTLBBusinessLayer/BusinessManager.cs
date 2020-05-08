using RVTLBBusinessLayer.Entities;
using RVTLBBusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
