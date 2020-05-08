

using RVTLibrary.Algoritms;
using System;
using System.Runtime.Serialization;
using RVTLibrary.Exceptions;

namespace RVTLibrary
{
    [DataContract]
    public class Block : IHashable
    {
        private IAlgorithm _algorithm = AlgorithmHelper.GetDefaultAlgorithm();
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public string Hash { get; set; }
        [DataMember]
        public string PreviousHash { get; set; }
        [DataMember]
        public int Party_Choosed { get; set; }
        [DataMember]
        public int Region_Choosed { get; set; }
        [DataMember]
        public string ChooserName { get; set; }
        [DataMember]
        public string Status { get; set; }

        /// <summary>
        ///  Constructor for Genesys Block
        /// </summary>
        public Block(IAlgorithm algorithm = null)
        {
            ID = 1;
            CreatedOn = DateTime.Parse("17.03.2020 00:00:00.000");
            Hash = this.GetHash(_algorithm);
            PreviousHash = _algorithm.GetHash("79098738-8772-4F0A-998D-9EC7737720F4");
            Hash = this.GetHash(_algorithm);
            ChooserName = "Admin";
            Party_Choosed = 352;
            Region_Choosed = 1;
        }
   
        public Block(Chooser chooser, Block block)
        {
            ID = block.ID;
            CreatedOn = DateTime.Now;
            PreviousHash = block.Hash;
            ChooserName = chooser.UserName;
            Region_Choosed = chooser.Region;
            Party_Choosed = chooser.Party_Choosed;
            Hash = this.GetHash();
        }
        public static Block GetGenesisBlock(IAlgorithm algorithm = null)
        {
            if (algorithm == null)
            {
                algorithm = AlgorithmHelper.GetDefaultAlgorithm();
            }

            var genesisBlock = new Block(algorithm);
            return genesisBlock;
        }
        public override string ToString()
        {
            return Hash;
        }

        public string GetStringForHas()
        {
            var data = "";
            data += ID;
            data += ChooserName;
            data += Party_Choosed;
            data += Region_Choosed;
            data += PreviousHash;
            data += Hash;
            return data;
        }
    }

}
