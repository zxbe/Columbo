using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class SequrityCode : BaseEntity
    {
        public Guid SessionId { get; private set; }
        public int Code { get; private set; }

        public SequrityCode(int creatorId, Guid sessionId, int code)
            : base(creatorId)
        {
            SessionId = sessionId;
            Code = code;
        }
    }
}
