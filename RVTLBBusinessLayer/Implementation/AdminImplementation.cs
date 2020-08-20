using RVTLBBusinessLayer.Entities;
using RVTLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RVTLBBusinessLayer.Implementation
{
    public class AdminImplementation
    {
        internal async Task<List<Node>> NodesAction()
        {
            NodeList nodelist = NodeList.GetInstance();
            List<Node> list = nodelist.GetList();
            return list;
        }
    }
}
