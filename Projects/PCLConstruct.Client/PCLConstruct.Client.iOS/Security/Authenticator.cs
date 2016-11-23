using Microsoft.IdentityModel.Clients.ActiveDirectory;
using PCLConstruct.Client.Security;
using System;
using System.Linq;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PCLConstruct.Client.iOS.Security.Authenticator))]
namespace PCLConstruct.Client.iOS.Security
{
    class Authenticator : IAuthenticator
    {
        public async Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, string returnUri)
        {
            var authContext = new AuthenticationContext(authority);
            //if (authContext.TokenCache.ReadItems().Any())
            //    authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);


            var controller = UIApplication.SharedApplication.KeyWindow.RootViewController;
            var uri = new Uri(returnUri);
            var platformParams = new PlatformParameters(controller);
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