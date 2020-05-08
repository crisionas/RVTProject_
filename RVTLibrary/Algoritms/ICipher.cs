using RVT_Block_lib.Models;
using RVT_Block_lib.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace RVTLibrary.Algoritms
{
    [ContractClass(typeof(ICipherContract))]
    public interface ICipher
    {
        public string Encrypt(NodeRegMessage node);
        public NodeRegResponse Decrypt(string encrypt);
    }
    [ContractClassFor(typeof(ICipher))]
    internal abstract class ICipherContract : ICipher
    {
        public NodeRegResponse Decrypt(string encrypted)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(encrypted), $"Decryption was not possible. Argument  {nameof(encrypted)} don't have data.");
            Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));
            return null;
        }

        public string Encrypt(NodeRegMessage node)
        {
            Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));
            return string.Empty;
        }
    }
}
