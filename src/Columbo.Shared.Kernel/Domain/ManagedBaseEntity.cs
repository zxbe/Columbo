using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Kernel.Domain
{
    public abstract class ManagedBaseEntity : BaseEntity
    {
        public DateTime? UpdateDate { get; private set; }

        protected ManagedBaseEntity()
        {
        }

        public ManagedBaseEntity(int creatorId)
            : base(creatorId)
        {
        }
    }
}
