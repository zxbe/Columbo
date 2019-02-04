using Columbo.IdentityProvider.Api.Dtos;
using Columbo.IdentityProvider.Infrastructure.StoredProcedures;
using Columbo.Shared.Infrastructure;
using Columbo.Shared.Infrastructure.SqlTypes;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Columbo.Shared.Infrastructure.Helpers.DynamicParameterHelper;

namespace Columbo.IdentityProvider.Sts.Stores
{
    public class ResourceStore : IResourceStore
    {
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;

        public ResourceStore(IStoredProcedureExecutor storedProcedureExecutor)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
        }

        private void AddRequiredIdentityResources(List<IdentityResource> identityResources)
        {
            identityResources.Add(new IdentityResources.OpenId());
        }

        public Task<ApiResource> FindApiResourceAsync(string name)
        {
            var apiResource = _storedProcedureExecutor
                .Execute<ApiResourceDto, string>(AsParameter(name, "apiResourceName"), ResourceStoredProcedureEnum.GetApiResourceByName, true, "ClaimType")
                .FirstOrDefault();

            if (apiResource == null)
                return Task.FromResult<ApiResource>(null);

            var identityServerApiResource = new ApiResource
            {
                Name = apiResource.Name,
                UserClaims = apiResource.ClaimTypes,
                Description = apiResource.Description
            };

            return Task.FromResult(identityServerApiResource);
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var parameter = new StringList(scopeNames.ToList()).AsTableValuedParameter("apiResourcesNames");

            var apiResources = _storedProcedureExecutor
                .Execute<ApiResourceDto, string>(parameter, ResourceStoredProcedureEnum.GetApiResourcesByNames, true, "ClaimType");
            
            var identityServerApiResources = apiResources.Select(x =>
                new ApiResource
                {
                    Name = x.Name,
                    DisplayName = x.Name,
                    Description = x.Description,
                    UserClaims = x.ClaimTypes
                });

            return Task.FromResult(identityServerApiResources);
        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var parameter = new StringList(scopeNames.ToList()).AsTableValuedParameter("identityResourcesNames");

            var identityResources = _storedProcedureExecutor
                .Execute<IdentityResourceDto, string>(parameter, ResourceStoredProcedureEnum.GetIdentityResourcesByNames, true, "ClaimType");
            
            var identityServerIdentityResources = identityResources.Select(x =>
                new IdentityResource
                {
                    Name = x.Name,
                    DisplayName = x.Name,
                    Description = x.Description,
                    UserClaims = x.ClaimTypes
                }).ToList();

            AddRequiredIdentityResources(identityServerIdentityResources);

            return Task.FromResult(identityServerIdentityResources.AsEnumerable());
        }

        public Task<Resources> GetAllResourcesAsync()
        {
            var apiResources = _storedProcedureExecutor
                .Execute<ApiResourceDto, string>(null, ResourceStoredProcedureEnum.GetAllApiResources, true, "ClaimType");

            var identityResources = _storedProcedureExecutor
                .Execute<IdentityResourceDto, string>(null, ResourceStoredProcedureEnum.GetAllIdentityResources, true, "ClaimType");

            var identityServerApiResources = apiResources.Select(x =>
                new ApiResource
                {
                    Name = x.Name,
                    DisplayName = x.Name,
                    Description = x.Description,
                    UserClaims = x.ClaimTypes
                });

            var identityServerIdentityResources = identityResources.Select(x =>
                new IdentityResource
                {
                    Name = x.Name,
                    DisplayName = x.Name,
                    Description = x.Description,
                    UserClaims = x.ClaimTypes,
                    ShowInDiscoveryDocument = x.ShowInDiscoveryDocument
                }).ToList();

            AddRequiredIdentityResources(identityServerIdentityResources);

            var resources = new Resources(identityServerIdentityResources, identityServerApiResources);

            return Task.FromResult(resources);
        }
    }
}
