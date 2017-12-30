using System;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain
{
    public class Block
    {
        private int _index;
        private DateTime _timestamp;
        private string _data;
        private string _previousHash;
        private string _hash;
       public Block(int index,DateTime timestamp,string data,string previousHash = "")
        {
            this._index = index;
            this._timestamp = timestamp;
            this._data = data;
            this._previousHash = previousHash;
            this._hash = this.CalculateHash();
        }

       
        public int Index { get { return this._index; } }
        public DateTime TimeStamp { get { return this._timestamp; } }
        public string Data { get { return this._data; } }
        public string PreviousHash { set { this._previousHash = value; } get { return this._previousHash; } }
        public string Hash { get { return this._hash; } }
        private string CalculateHash()
        {
            string blockHasableData = string.Concat(this._index, this._timestamp, this._data, this._previousHash);
            SHA256 sHA256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(blockHasableData);
            byte[] hashbytes = sHA256.ComputeHash(bytes);

            StringBuilder hashString = new StringBuilder();
            foreach(byte b in hashbytes)
            {
                hashString.Append(b.ToString("X2"));
            }
            return hashString.ToString();
        }
    }
}
