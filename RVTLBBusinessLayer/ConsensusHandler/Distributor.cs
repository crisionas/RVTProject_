﻿using RVT_Block_lib.Models;
using RVTLBBusinessLayer.Entities;
using RVTLBBusinessLayer.Sender;
using RVTLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RVTLBBusinessLayer.ConsensusHandler
{
    public class Distributor : IDistributor, ISender
    {
        private IEnumerable<Node> ChoosedNodes;
        private readonly ISender _sender;
        public Node Executor { get; set; }

        public Distributor(ISender sender)
        {
            _sender = sender;
        }


        public NodeVoteMessage FormateMessage(ChooserLbMessage message)
        {
            var data = new NodeVoteMessage();
            data.message = message;
            data.NeighBours = ChoosedNodes.ToList();
            return data;
        }

        public IEnumerable<Node> FormateNodeList(int i)
        {
            var data = NodeList.GetInstance();
            var list = data.GetList();
            var random = new Random();
            var point = random.Next(list.Count());
            ChoosedNodes = list.OrderBy(x => random.Next()).Where(m => m.NodeId != list[point].NodeId).Take(i).Distinct();
            return ChoosedNodes;
        }

        public string Send(Node node, object package)
        {
           return  _sender.Send(node, package);
        }

    }
}
