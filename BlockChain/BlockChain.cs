using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace BlockChain
{
    public class Chain
    {
        private List<Block> chain;
        public Chain()
        {
            this.chain = new List<Block>();
            this.chain.Add(createGenesisBlock());            
        }

        private Block createGenesisBlock()
        {
            return new Block(0, DateTime.Parse("12/28/2017"), "Sam's Genesis Block", "0");
        }

        public Block GetLatestBlock()
        {
            return this.chain[this.chain.Count - 1];
        }

        public void AddBlock(Block block)
        {
            block.PreviousHash = GetLatestBlock().Hash;
            // Calculate Hash block.hash=block.CalculateHsh()
            this.chain.Add(block);
        }

        public string GetJsonChain()
        {
          return  JsonConvert.SerializeObject(this.chain);
        }
    }

}
