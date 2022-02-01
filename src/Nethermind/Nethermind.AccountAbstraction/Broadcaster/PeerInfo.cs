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

using System.Collections.Generic;
using Nethermind.AccountAbstraction.Data;
using Nethermind.Core.Caching;
using Nethermind.Core.Crypto;

namespace Nethermind.AccountAbstraction.Broadcaster
{
    public class PeerInfo : IUserOperationPoolPeer
    {
        private IUserOperationPoolPeer Peer { get; }

        private LruKeyCache<Keccak> NotifiedUserOperations { get; } = new(MemoryAllowance.MemPoolSize, "notifiedUserOperations");

        public PeerInfo(IUserOperationPoolPeer peer)
        {
            Peer = peer;
        }

        public PublicKey Id => Peer.Id;

        public void SendNewUserOperation(UserOperation uop)
        {
            if (NotifiedUserOperations.Set(uop.Hash))
            {
                Peer.SendNewUserOperation(uop);
            }
        }

        public void SendNewUserOperations(IEnumerable<UserOperation> uops)
        {
            Peer.SendNewUserOperations(GetUOpsToSendAndMarkAsNotified(uops));
        }

        private IEnumerable<UserOperation> GetUOpsToSendAndMarkAsNotified(IEnumerable<UserOperation> uops)
        {
            foreach (UserOperation uop in uops)
            {
                if (NotifiedUserOperations.Set(uop.Hash))
                {
                    yield return uop;
                }
            }
        }

        public override string ToString() => Peer.Enode;
    }
}
