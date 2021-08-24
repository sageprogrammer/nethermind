//  Copyright (c) 2021 Demerzel Solutions Limited
//  This file is part of the Nethermind library.
// 
//  The Nethermind library is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  The Nethermind library is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.
// 

using System;
using Nethermind.Abi;
using Nethermind.AccountAbstraction.Broadcaster;
using Nethermind.Core;
using Nethermind.Core.Crypto;
using Nethermind.Core.Eip2930;
using Nethermind.Int256;

namespace Nethermind.AccountAbstraction.Data
{
    public partial class UserOperation
    {
        public UserOperation(Address target, UInt256 nonce, byte[] callData, byte[] initCode, long callGas, long verificationGas, UInt256 maxFeePerGas, UInt256 maxPriorityFeePerGas, Address paymaster, Address signer, Signature signature, AccessList accessList)
        {
            Target = target;
            Nonce = nonce;
            CallData = callData;
            InitCode = initCode;
            CallGas = callGas;
            VerificationGas = verificationGas;
            MaxFeePerGas = maxFeePerGas;
            MaxPriorityFeePerGas = maxPriorityFeePerGas;
            Paymaster = paymaster;
            Signer = signer;
            Signature = signature;
            AccessList = accessList;
            
            Hash = CalculateHash(this);
        }

        public UserOperation() {}

        public UserOperationAbi Abi { get; set; }

        public Keccak? Hash { get; set; }
        public Address? Target { get; set; }
        public UInt256 Nonce { get; set; }
        public byte[]? CallData { get; set; }
        public byte[]? InitCode { get; set; }
        public long CallGas { get; set; }
        public long VerificationGas { get; set; }
        public UInt256 MaxFeePerGas { get; set; }
        public UInt256 MaxPriorityFeePerGas { get; set; }
        public Address? Paymaster { get; set; }
        public Address? Signer { get; set; }
        public Signature? Signature { get; set; }
        public AccessList? AccessList { get; set; }
        public int ResimulationCounter { get; set; }
        public bool AccessListTouched { get; set; }
    }

    public struct UserOperationAbi
    {
        public Address Target { get; set; }
        public UInt256 Nonce { get; set; }
        public byte[] InitCode { get; set; }
        public byte[] CallData { get; set; }
        public ulong CallGas { get; set; }
        public ulong VerificationGas { get; set; }
        public ulong MaxFeePerGas { get; set; }
        public ulong MaxPriorityFeePerGas { get; set; }
        public Address Paymaster { get; set; }
        
        [AbiTypeMapping(typeof(AbiBytes), 32)]
        public byte[] VerificationAccessListHash { get; set; }
        public Address Signer { get; set; }
        public byte[] Signature { get; set; }
    }
}