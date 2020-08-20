using RVTLBBusinessLayer.Implementation;
using RVTLBBusinessLayer.Interfaces;
using RVTLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RVTLBBusinessLayer.Entities
{
    public class Admin : AdminImplementation, IAdmin
    {
        Task<List<Node>> IAdmin.Nodes()
        {
            return NodesAction();
        }
    }
}
