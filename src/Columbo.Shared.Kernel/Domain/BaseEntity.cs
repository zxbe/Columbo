﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Kernel.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
        public int CreatorId { get; private set; }
        public DateTime CreateDate { get; private set; }

        protected BaseEntity()
        {
        }

        public BaseEntity(int creatorId)
        {
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }

        public BaseEntity(int id, int creatorId)
        {
            Id = id;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }
    }
}
