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
                .ExecuteSingle<ApiResourceDto>(AsParameter(name, "apiResourceName"), ResourceStoredProcedureEnum.GetApiResourceByName);

            var claims = _storedProcedureExecutor
                .Execute<string>(AsParameter(apiResource.Id, "apiResourceId"), ResourceStoredProcedureEnum.GetApiResourceClaims);

            apiResource.ClaimTypes = claims.ToList();

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
                .Execute<ApiResourceDto>(parameter, ResourceStoredProcedureEnum.GetApiResourcesByNames);

            var apiResourcesIdParameter = new IntList(apiResources.Select(x => x.Id).ToList()).AsTableValuedParameter("apiResourcesId");
            var apiResourcesClaims = _storedProcedureExecutor
                .Execute<ResourceClaimDto>(apiResourcesIdParameter, ResourceStoredProcedureEnum.GetApiResourcesClaims);
            
            var identityServerApiResources = new List<ApiResource>();
            foreach (var apiResource in apiResources)
            {
                apiResource.ClaimTypes = apiResourcesClaims
                    .Where(x => x.ResourceId == apiResource.Id)
                    .Select(x => x.ClaimType)
                    .ToList();

                var identityServerApiResource = new ApiResource
                {
                    Name = apiResource.Name,
                    DisplayName = apiResource.Name,
                    Description = apiResource.Description,
                    UserClaims = apiResource.ClaimTypes
                };

                identityServerApiResources.Add(identityServerApiResource);
            }

            return Task.FromResult(identityServerApiResources.AsEnumerable());
        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var parameter = new StringList(scopeNames.ToList()).AsTableValuedParameter("identityResourcesNames");
            var identityResources = _storedProcedureExecutor
                .Execute<IdentityResourceDto>(parameter, ResourceStoredProcedureEnum.GetIdentityResourcesByNames);

            var identityResourcesIdParameter = new IntList(identityResources.Select(x => x.Id).ToList()).AsTableValuedParameter("identityResourcesId");
            var identityResourcesClaims = _storedProcedureExecutor
                .Execute<ResourceClaimDto>(identityResourcesIdParameter, ResourceStoredProcedureEnum.GetIdentityResourcesClaims);

            var identityServerIdentityResources = new List<IdentityResource>();
            foreach (var identityResource in identityResources)
            {
                identityResource.ClaimTypes = identityResourcesClaims
                    .Where(x => x.ResourceId == identityResource.Id)
                    .Select(x => x.ClaimType)
                    .ToList();

                var identityServerIdentityResource = new IdentityResource()
                {
                    Name = identityResource.Name,
                    DisplayName = identityResource.Name,
                    Description = identityResource.Description,
                    UserClaims = identityResource.ClaimTypes
                };

                identityServerIdentityResources.Add(identityServerIdentityResource);
            }
            AddRequiredIdentityResources(identityServerIdentityResources);

            return Task.FromResult(identityServerIdentityResources.AsEnumerable());
        }

        public Task<Resources> GetAllResourcesAsync()
        {
            var apiResources = _storedProcedureExecutor
                .Execute<ApiResourceDto>(ResourceStoredProcedureEnum.GetAllApiResources);

            var identityResources = _storedProcedureExecutor
                .Execute<IdentityResourceDto>(ResourceStoredProcedureEnum.GetAllIdentityResources);

            var apiResourcesIdParameter = new IntList(apiResources.Select(x => x.Id).ToList()).AsTableValuedParameter("apiResourcesId");
            var apiResourcesClaims = _storedProcedureExecutor
                .Execute<ResourceClaimDto>(apiResourcesIdParameter, ResourceStoredProcedureEnum.GetApiResourcesClaims);

            var identityResourcesIdParameter = new IntList(identityResources.Select(x => x.Id).ToList()).AsTableValuedParameter("identityResourcesId");
            var identityResourcesClaims = _storedProcedureExecutor
                .Execute<ResourceClaimDto>(identityResourcesIdParameter, ResourceStoredProcedureEnum.GetIdentityResourcesClaims);

            var identityServerApiResources = new List<ApiResource>();
            foreach (var apiResource in apiResources)
            {
                apiResource.ClaimTypes = apiResourcesClaims
                    .Where(x => x.ResourceId == apiResource.Id)
                    .Select(x => x.ClaimType)
                    .ToList();

                var identityServerApiResource = new ApiResource
                {
                    Name = apiResource.Name,
                    DisplayName = apiResource.Name,
                    Description = apiResource.Description,
                    UserClaims = apiResource.ClaimTypes
                };

                identityServerApiResources.Add(identityServerApiResource);
            }
            
            var identityServerIdentityResources = new List<IdentityResource>();
            foreach (var identityResource in identityResources)
            {
                identityResource.ClaimTypes = identityResourcesClaims
                    .Where(x => x.ResourceId == identityResource.Id)
                    .Select(x => x.ClaimType)
                    .ToList();

                var identityServerIdentityResource = new IdentityResource()
                {
                    Name = identityResource.Name,
                    DisplayName = identityResource.Name,
                    Description = identityResource.Description,
                    UserClaims = identityResource.ClaimTypes,
                    ShowInDiscoveryDocument = identityResource.ShowInDiscoveryDocument
                };

                identityServerIdentityResources.Add(identityServerIdentityResource);
            }

            AddRequiredIdentityResources(identityServerIdentityResources);

            var resources = new Resources(identityServerIdentityResources.AsEnumerable(), identityServerApiResources.AsEnumerable());

            return Task.FromResult(resources);
        }
    }
}
