using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Kernel.Domain
{
    public class DictionaryBaseEntity : BaseEntity
    {
        public string Name { get; private set; }

        protected DictionaryBaseEntity()
        {
        }

        public DictionaryBaseEntity(int creatorId, string name)
            : base(creatorId)
        {
            Name = name;
        }

        public DictionaryBaseEntity(int id, int creatorId, string name)
            : base(id, creatorId)
        {
            Name = name;
        }
    }
}
