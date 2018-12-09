using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Kernel.Domain
{
    public abstract class AggregateRoot : ManagedBaseEntity
    {
        public int Version { get; private set; }

        protected AggregateRoot()
        {
        }

        public AggregateRoot(int creatorId)
            : base(creatorId)
        {
            Version = 1;
        }
    }
}
