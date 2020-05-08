using RVTLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVTLBBusinessLayer.Entities
{
    public class NodeList
    {
        private static readonly NodeList nodeList = new NodeList();
        public static List<Node> Nodes { get; private set; }
        private NodeList()
        {
            Nodes = new List<Node>();
        }
        public static NodeList GetInstance()
        {
            return nodeList;
        }
        public void AddNodes(Node node)
        {
            if (node != null)
            {
                Nodes.Add(node);
            }
        }

        public List<Node> GetList()
        {
            return Nodes;
        }
    }
}
