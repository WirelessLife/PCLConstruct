using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using System.Net.Http.Headers;
using PCLConstruct.Client.Helpers;

namespace PCLConstruct.Client.Security
{
    public class AzureADAuth
    {
        private string clientId = SettingsHelper.GetConfig("ClientID");//"2a2a6954-856e-4dea-ab07-3cefffdfc65c"; 
        private string authority = SettingsHelper.GetConfig("Authority");
        private string returnUri = SettingsHelper.GetConfig("ReturnURI");
        private string graphResourceUri = SettingsHelper.GetConfig("GraphURI");
        public AuthenticationResult authResult = null;
        

        public async void AuthenticateUser()
        {
            var auth = DependencyService.Get<IAuthenticator>();
            authResult = await auth.Authenticate(authority, graphResourceUri, clientId, returnUri);
            var userName = authResult.UserInfo.GivenName + " " + authResult.UserInfo.FamilyName;
            
        }

        public void ClearCache()
        {
            var auth = DependencyService.Get<IAuthenticator>();
            auth.ClearCache(authority);
        }

        public void BuildAuthHeader(ref HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("Bearer", authResult.AccessToken);
        }
    }

    public interface IAuthenticator
    {
        Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, string returnUri);
        void ClearCache(string authority);
    }

}
