using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class UserIdentity : AggregateRoot
    {
        public int UserId { get; private set; }
        public string Login { get; private set; }
        public string PasswordHash { get; private set; }
        public bool IsActive { get; private set; }
        public User User { get; private set; }
        public ICollection<UserDevice> UserDevices { get; private set; }
        public ICollection<UserRole> UserRoles { get; private set; }

        protected UserIdentity()
        {
            UserDevices = new List<UserDevice>();
            UserRoles = new List<UserRole>();
        }
        
        public UserIdentity(int creatorId, User user, string login, string passwordHash)
            : base(creatorId)
        {
            User = user;
            Login = login;
            PasswordHash = passwordHash;
            IsActive = true;

            UserDevices = new List<UserDevice>();
            UserRoles = new List<UserRole>();
        }

        public void AddRoles(List<int> rolesId, int creatorId)
        {
            rolesId.ForEach(x => UserRoles.Add(new UserRole(creatorId, this.Id, x)));
        }

        public void Archive()
        {
            IsActive = false;
        }
    }
}
