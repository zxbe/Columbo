﻿using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class UserIdentity : AggregateRoot
    {
        public int UserId { get; private set; }
        public string Login { get; private set; }
        public int PasswordHash { get; private set; }
        public bool IsActive { get; private set; }
        public User User { get; private set; }
        public ICollection<UserDevice> UserDevices { get; private set; }
        public ICollection<UserRole> UserRoles { get; private set; }
        
        public UserIdentity(int creatorId, int userId, string login, string password)
            : base(creatorId)
        {
            UserId = userId;
            Login = login;
            PasswordHash = password.GetHashCode();
            IsActive = true;

            UserDevices = new List<UserDevice>();
            UserRoles = new List<UserDevice>();
        }
    }
}
