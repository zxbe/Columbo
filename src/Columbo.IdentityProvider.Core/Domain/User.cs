using Columbo.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class User : ManagedBaseEntity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string EmailAddress { get; private set; }
        public bool IsActive { get; private set; }

        public User(int creatorId, string name, string surname, string emailAddress)
            : base(creatorId)
        {
            Name = name;
            Surname = surname;
            EmailAddress = emailAddress;
            IsActive = true;
        }
    }
}
