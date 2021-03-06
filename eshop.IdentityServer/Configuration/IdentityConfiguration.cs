using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace eshop.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Client = "Client";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> apiScopes =>
            new List<ApiScope>
            {
                new ApiScope("eshop_shopping", "eshopShopping Server"),
                new ApiScope(name: "read", "Read data."),
                new ApiScope(name: "Write", "Write data."),
                new ApiScope(name: "Delete", "Delete data."),
            };

        public static IEnumerable<Client> clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("my_super_secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read","write","profile" }
                },
                 new Client
                {
                    ClientId = "eshop_shopping",
                    ClientSecrets = { new Secret("my_super_secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                     RedirectUris = {"https://localhost:4430/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:4430/signout-callback-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "eshop_shopping"
                    }
                }
            };
    }
}
