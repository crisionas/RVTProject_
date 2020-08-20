using RVTLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RVTLBBusinessLayer.Interfaces
{
    public interface IAdmin
    {
        public Task<List<Node>> Nodes();
    }
}
