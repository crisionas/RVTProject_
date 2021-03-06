﻿using System.Diagnostics.Contracts;

namespace RVTLibrary.Algoritms
{
    [ContractClass(typeof(IHashableContract))]
    public interface IHashable
    {
        string Hash { get; }
        string GetStringForHas();
    }
    [ContractClassFor(typeof(IHashable))]
    internal abstract class IHashableContract : IHashable
    {
        string IHashable.Hash
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));
                return string.Empty;
            }
        }

        string IHashable.GetStringForHas()
        {
            Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));
            return string.Empty;
        }
    }
}
