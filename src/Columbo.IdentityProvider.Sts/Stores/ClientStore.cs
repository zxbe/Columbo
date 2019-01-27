using Columbo.IdentityProvider.Api.Dtos;
using Columbo.IdentityProvider.Infrastructure.StoredProcedures;
using Columbo.Shared.Infrastructure;
using Columbo.Shared.Infrastructure.Helpers;
using Dapper;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static Columbo.Shared.Infrastructure.Helpers.DynamicParameterHelper;

namespace Columbo.IdentityProvider.Sts.Stores
{
    public class ClientStore : IClientStore
    {
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;

        public ClientStore(IStoredProcedureExecutor storedProcedureExecutor)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var clientGuid = new Guid(clientId);
            
            var client = _storedProcedureExecutor
                .ExecuteSingle<ClientDto>(AsParameter(clientGuid, "clientGuid"), ClientStoredProcedureEnum.GetClientByGuid);

            var clientIdParameter = AsParameter(client.Id, "clientId");

            var clientIdentityResources = _storedProcedureExecutor
                .Execute<IdentityResourceDto>(clientIdParameter, ClientStoredProcedureEnum.GetClientIdentityResources);

            var clientApiResources = _storedProcedureExecutor
                .Execute<ApiResourceDto>(clientIdParameter, ClientStoredProcedureEnum.GetClientApiResources);

            client.IdentityResources = clientIdentityResources.ToList();
            client.ApiResources = clientApiResources.ToList();

            var scopes = new List<string>(client
                    .ApiResources.Select(x => x.Name)
                    .Union(client.IdentityResources.Select(x => x.Name)));

            scopes.Add("openid");

            var identityServerClient = new Client
            {
                ClientId = client.ClientGuid.ToString(),
                ClientName = client.Name,
                Description = client.Description,
                IdentityTokenLifetime = client.IdentityTokenLifetime,
                AccessTokenLifetime = client.AccessTokenLifetime,
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowedScopes = scopes,
                RequireConsent = false,
            ClientSecrets = new List<Secret>()
                {
                    new Secret(client.SecretHash)
                },
                RedirectUris = new List<string>()
                {
                    client.RedirectUri
                },
                PostLogoutRedirectUris = new List<string>()
                {
                    client.PostLogoutRedirectUri
                },
            };

            return Task.FromResult(identityServerClient);
        }
    }
}
