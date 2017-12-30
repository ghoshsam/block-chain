using BlockChain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BlockChainConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("My Block Chain Implementation");

            Chain myCoin = new Chain();
            myCoin.AddBlock(new Block(1, DateTime.Parse("12/29/2017"), "block 1"));

            myCoin.AddBlock(new Block(2, DateTime.Parse("12/29/2017"), "block 2"));

            //string JsonChain = JsonConvert.SerializeObject(myCoin);

            Console.Write(JValue.Parse(myCoin.GetJsonChain()).ToString(Formatting.Indented));
            Console.ReadLine();
        }
    }
}
