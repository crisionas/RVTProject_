
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using RVTLibrary.Exceptions;

namespace RVTLibrary
{
    public class Chain
    {
        /// <summary>
        /// List of blocks.
        /// </summary>
        public List<Block> Blocks = new List<Block>();
        public int Length => Blocks.Count;
        public IEnumerable<Block> BlockChain => Blocks;
        public Block PreviousBlock => Blocks.Last();

        /// <summary>
        /// Create a new prototype of Blockchain.
        /// </summary>
        public Chain()
        {
                CreateNewBlockChain();
        }
        /// <summary>
        /// Add block.
        /// </summary>
        /// <param name="block"></param>
        private void Add(Block block)
        {
            if (Blocks.Any(b => b.Hash == block.Hash))
            {
                return;
            }
            Blocks.Add(block);
        }
            /// <summary>
            /// Create new Block.
            /// </summary>
            private void CreateNewBlockChain()
        {
            Blocks = new List<Block>();
            var genesisBlock = new Block();
            Blocks.Add(genesisBlock);
            //PreviousBlock = genesisBlock;
        }
        /// <summary>
        /// Verify if blockchain was correct created.
        /// </summary>
        /// <returns></returns>
        public bool Check()
        {
            var genesisBlock = new Block();
            var prevHash = genesisBlock.Hash;

            foreach(var block in Blocks.Skip(1))
            {
                var hash = block.PreviousHash;

                if (prevHash != hash)
                {
                    return false;
                }
                prevHash = block.Hash;
            }
            return true;
        }

    }

}
