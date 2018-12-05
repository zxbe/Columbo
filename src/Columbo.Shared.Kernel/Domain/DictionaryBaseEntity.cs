using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Kernel.Domain
{
    public class DictionaryBaseEntity : BaseEntity
    {
        public string Name { get; private set; }

        public DictionaryBaseEntity(int creatorId, string name)
            : base(creatorId)
        {
            Name = name;
        }
    }
}
