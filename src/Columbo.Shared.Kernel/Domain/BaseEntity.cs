using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Kernel.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
        public int CreatorId { get; private set; }
        public DateTime CreateDate { get; private set; }

        public BaseEntity(int creatorId)
        {
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }
    }
}
