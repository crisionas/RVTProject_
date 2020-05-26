

using RVTLibrary.Algoritms;
using System;
using System.Runtime.Serialization;
using RVTLibrary.Exceptions;

namespace RVTLibrary
{
    public class Block
    {
        public int BlockId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Hash { get; set; }
        public string PreviousHash { get; set; }
        public int? PartyChoosed { get; set; }
        public int? RegionChoosed { get; set; }
        public string Gender { get; set; }
        public int? YearToBirth { get; set; }
        public string Idbd { get; set; }
    }

}
