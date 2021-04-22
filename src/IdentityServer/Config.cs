using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace amznStore.IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "amznClient",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = new List<string> { GrantType.ClientCredentials },

                    // where to redirect to after login
                    RedirectUris = { "https://localhost:5002/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                    AllowOfflineAccess = true,

                    AllowedCorsOrigins = new List<string>
                    {
                        "https://localhost:5001",
                    },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "catalogApi",
                        "write",
                        "read"
                    }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
           new ApiScope[]
           {
               new ApiScope("CatalogAPI", "Catalog API"),
               new ApiScope("read"),
               new ApiScope("write")
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

        public static IEnumerable<IdentityResource> IdentityResources =>
          new IdentityResource[]
          {
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
              new IdentityResources.Address(),
              new IdentityResources.Email(),
              new IdentityResource(
                    "roles",
                    "Your role(s)",
                    new List<string>() { "role" })
          };

        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "mehmet",
                    Password = "swn",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "mehmet"),
                        new Claim(JwtClaimTypes.FamilyName, "ozkaya")
                    }
                }
            };
    }
}
