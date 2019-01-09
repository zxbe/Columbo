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

namespace Columbo.IdentityProvider.Api.Stores
{
    public class ResourceStore : IResourceStore
    {
        private readonly IStoredProcedureExecutor<StoredProcedureEnum> _storedProcedureExecutor;

        public ResourceStore(IStoredProcedureExecutor<StoredProcedureEnum> storedProcedureExecutor)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
        }

        public Task<ApiResource> FindApiResourceAsync(string name)
        {
            var apiResource = _storedProcedureExecutor.ExecuteSingle<ApiResourceDto>(AsParameter(name, "apiResourceName"), StoredProcedureEnum.GetApiResourceByName);
            var claims = _storedProcedureExecutor.Execute<string>(AsParameter(apiResource.Id, "apiResourceId"), StoredProcedureEnum.GetApiResourceClaims);
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
            var apiResources = _storedProcedureExecutor.Execute<ApiResourceDto>(parameter, StoredProcedureEnum.GetApiResourcesByNames);

            var identityServerApiResources = new List<ApiResource>();
            foreach (var apiResource in apiResources)
            {
                var claims = _storedProcedureExecutor.Execute<string>(AsParameter(apiResource.Id, "apiResourceId"), StoredProcedureEnum.GetApiResourceClaims);
                apiResource.ClaimTypes = claims.ToList();

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
            var identityResources = _storedProcedureExecutor.Execute<IdentityResourceDto>(parameter, StoredProcedureEnum.GetIdentityResourcesByNames);

            var identityServerIdentityResources = new List<IdentityResource>();
            foreach (var identityResource in identityResources)
            {
                var claims = _storedProcedureExecutor.Execute<string>(AsParameter(identityResource.Id, "identityResourceId"), StoredProcedureEnum.GetIdentityResourceClaims);
                identityResource.ClaimTypes = claims.ToList();

                var identityServerIdentityResource = new IdentityResource()
                {
                    Name = identityResource.Name,
                    DisplayName = identityResource.Name,
                    Description = identityResource.Description,
                    UserClaims = identityResource.ClaimTypes
                };
            }

            return Task.FromResult(identityServerIdentityResources.AsEnumerable());
        }

        public Task<Resources> GetAllResourcesAsync()
        {
            var apiResources = _storedProcedureExecutor.Execute<ApiResourceDto>(StoredProcedureEnum.GetAllApiResources);
            var identityResources = _storedProcedureExecutor.Execute<IdentityResourceDto>(StoredProcedureEnum.GetAllIdentityResources);

            var identityServerApiResources = new List<ApiResource>();
            foreach (var apiResource in apiResources)
            {
                var claims = _storedProcedureExecutor.Execute<string>(AsParameter(apiResource.Id, "apiResourceId"), StoredProcedureEnum.GetApiResourceClaims);
                apiResource.ClaimTypes = claims.ToList();

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
                var claims = _storedProcedureExecutor.Execute<string>(AsParameter(identityResource.Id, "identityResourceId"), StoredProcedureEnum.GetIdentityResourceClaims);
                identityResource.ClaimTypes = claims.ToList();

                var identityServerIdentityResource = new IdentityResource()
                {
                    Name = identityResource.Name,
                    DisplayName = identityResource.Name,
                    Description = identityResource.Description,
                    UserClaims = identityResource.ClaimTypes
                };
            }

            var resources = new Resources(identityServerIdentityResources.AsEnumerable(), identityServerApiResources.AsEnumerable());

            return Task.FromResult(resources);
        }
    }
}
