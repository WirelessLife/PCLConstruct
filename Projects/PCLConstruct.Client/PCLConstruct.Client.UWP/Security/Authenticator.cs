using Microsoft.IdentityModel.Clients.ActiveDirectory;
using PCLConstruct.Client.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(PCLConstruct.Client.UWP.Security.Authenticator))]
namespace PCLConstruct.Client.UWP.Security
{
    class Authenticator : IAuthenticator
    {
        public async Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, string returnUri)
        {
            var authContext = new AuthenticationContext(authority);
            //if (authContext.TokenCache.ReadItems().Any())
            //    authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);

            var uri = new Uri(returnUri);
            var platformParams = new PlatformParameters(PromptBehavior.Auto, true);
            var authResult = await authContext.AcquireTokenAsync(resource, clientId, uri, platformParams);
            return authResult;
        }

        public void ClearCache(string authority)
        {
            var authContext = new AuthenticationContext(authority);
            authContext.TokenCache.Clear();
        }
    }
}
