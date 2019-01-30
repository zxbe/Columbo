using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Columbo.Shared.Api.Extensions;
using Columbo.Shared.Api.Security.Enums;
using Microsoft.EntityFrameworkCore;
using Columbo.IdentityProvider.Api.Enums;
using Columbo.Shared.Api.Security;

namespace Columbo.IdentityProvider.Api
{
    internal class DatabaseSeeder : IDatabaseSeeder
    {
        public void Seed(IDatabaseContext context)
        {
            //todo change seeder

            SeedClaim(context);
            var resource = SeedIdentityResource(context);
            SeedClient(context, resource.Id);
            SeedDeviceType(context);
            var instance = SeedInstance(context);
            var role = SeedSequrity(context);
            SeedUserIdentity(context, role.Id);
        }

        private void SeedUserIdentity(IDatabaseContext context, int roleId)
        {
            var user = new User(1, "Columbo", "System", "");
            var userIdentity = new UserIdentity(1, user, "admin", IdentityServer4.Models.HashExtensions.Sha256("changeThis!"));
            userIdentity.AddRoles(new List<int> { roleId }, 1);

            if (!context.Set<UserIdentity>().Where(x => x.IsActive && x.Login.Equals(userIdentity.Login)).Any())
            {
                context.Attach(userIdentity).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        private Role SeedSequrity(IDatabaseContext context)
        {
            var existingPermissions = context.Set<Permission>().ToList();
            var existingRoleTypes = context.Set<RoleType>().ToList();

            foreach (var permission in EnumExtension.ToList<PermissionEnum>())
            {
                if (!existingPermissions.Any(x => x.Id == permission.Value))
                {
                    var permissionEntity = new Permission(permission.Value, 1, permission.Description);
                    context.Attach(permissionEntity).State = EntityState.Added;
                }
            }

            foreach (var roleType in EnumExtension.ToList<RoleTypeEnum>())
            {
                if (!existingRoleTypes.Any(x => x.Id == roleType.Value))
                {
                    var roleTypeEntity = new RoleType(roleType.Value, 1, roleType.Description);
                    context.Attach(roleTypeEntity).State = EntityState.Added;
                }
            }

            var roleEntity = new Role(1, "System administrator", null, (int)RoleTypeEnum.Administrator);
            roleEntity.AddPermissions(new List<int>()
            {
                (int)PermissionEnum.OperationsOnUser,
                (int)PermissionEnum.OperationsOnUserDevice,
                (int)PermissionEnum.OperationsOnUserIdentity,
                (int)PermissionEnum.OperationsOnClient
            }, 1);

            var existingRole = context.Set<Role>().FirstOrDefault(x => x.Name.Equals(roleEntity.Name) && x.RoleTypeId == (int)RoleTypeEnum.Administrator);
            if (existingRole == null)
            {
                context.Attach(roleEntity).State = EntityState.Added;
            }

            context.SaveChanges();

            if (existingRole == null)
                return roleEntity;
            else
                return existingRole;
        }

        private Instance SeedInstance(IDatabaseContext context)
        {
            var instanceEntity = new Instance(1, "Main", "Main instance");
            var existingInstance = context.Set<Instance>().FirstOrDefault(x => x.Name.Equals(instanceEntity.Name));

            if (existingInstance == null)
            {
                context.Attach(instanceEntity).State = EntityState.Added;
                context.SaveChanges();

                return instanceEntity;
            }

            return existingInstance;
        }

        private void SeedDeviceType(IDatabaseContext context)
        {
            var existingDeviceTypes = context.Set<DeviceType>().ToList();

            foreach (var deviceType in EnumExtension.ToList<DeviceTypeEnum>())
            {
                if (!existingDeviceTypes.Any(x => x.Id == deviceType.Value))
                {
                    var deviceTypeEntity = new DeviceType(deviceType.Value, 1, deviceType.Description);
                    context.Attach(deviceTypeEntity).State = EntityState.Added;
                }
            }

            context.SaveChanges();
        }

        private void SeedClaim(IDatabaseContext context)
        {
            var existingClaims = context.Set<ClaimType>().ToList();
            var claimTypes = ClaimTypes.GetClaimTypes();

            foreach (var claimType in claimTypes)
            {
                if (!existingClaims.Any(x => x.Name == claimType.Key))
                {
                    var claimTypeEntity = new ClaimType(1, claimType.Key, claimType.Value);
                    context.Attach(claimTypeEntity).State = EntityState.Added;
                }
            }

            context.SaveChanges();
        }

        private IdentityResource SeedIdentityResource(IDatabaseContext context)
        {
            var existingIdentityResources = context.Set<IdentityResource>().ToList();

            var claims = context.Set<ClaimType>().ToList();

            var userIdentityResource = new IdentityResource(1, "UserIdentityResource", "-");
            userIdentityResource.AddClaims(claims, 1);

            if (!existingIdentityResources.Any(x => x.Name.Equals(userIdentityResource.Name)))
            {
                context.Attach(userIdentityResource).State = EntityState.Added;
                context.SaveChanges();
                return userIdentityResource;
            }
            else
                return existingIdentityResources.First(x => x.Name.Equals(userIdentityResource.Name));
        }

        private void SeedClient(IDatabaseContext context, int identityResourceId)
        {
            var existingCliens = context.Set<Client>().ToList();

            var client = new Client(1,
                new Guid("e6af38ec-9750-49c9-8351-c89e7386b1e7"),
                "mvc",
                "mvc test",
                IdentityServer4.Models.HashExtensions.Sha256("test"),
                new Uri("http://localhost:55128/signin-oidc"),
                new Uri("http://localhost:55128"), 600, 600, 600);

            client.AddIdentityResources(new List<int> { identityResourceId }, 1);

            if (!existingCliens.Any(x => x.ClientGuid == client.ClientGuid))
            {
                context.Attach(client).State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
