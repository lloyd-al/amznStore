using IdentityServer4.Models;
using System.Collections.Generic;

namespace amznStore.IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("catalogapi", "Product Catalog API")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "amznClient",

                    // secret for authentication
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = new List<string> { GrantType.ClientCredentials },

                    AllowOfflineAccess = true,

                    AllowedCorsOrigins = new List<string>
                    {
                        "https://localhost:44358",
                    },

                    // scopes that client has access to
                    AllowedScopes = {"catalogapi" }
                }
            };


        public static IEnumerable<ApiResource> ApiResources =>
          new ApiResource[]
          {
            new ApiResource
            {
                Name = "catalogApi",
                DisplayName = "Product Catalog API",
                Scopes = new List<string>
                {
                    "write",
                    "read"
                }
            }
          };
    }
}
