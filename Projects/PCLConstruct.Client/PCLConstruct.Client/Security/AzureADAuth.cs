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
        private AzureSettings settings = SettingsHelper.GetConfig();//"2a2a6954-856e-4dea-ab07-3cefffdfc65c"; 
        public AuthenticationResult authResult = null;

        /// <summary>
        /// This given and the family name for the authenticated user
        /// </summary>
        public string UserName { get; set; }

        public async Task AuthenticateUser()
        {
            var auth = DependencyService.Get<IAuthenticator>();
            authResult = await auth.Authenticate(settings.Authority, settings.GraphURI, settings.ClientID, settings.ReturnURI);
            if (string.IsNullOrEmpty(authResult.AccessToken) == false)
            {
                this.UserName = authResult.UserInfo.GivenName + " " + authResult.UserInfo.FamilyName;
            }
            OnAuthenticated(new EventArgs());
        }

        public void ClearCache()
        {
            var auth = DependencyService.Get<IAuthenticator>();
            auth.ClearCache(settings.Authority);
        }

        public void BuildAuthHeader(ref HttpClient httpClient)
        {
            var auth = DependencyService.Get<IAuthenticator>();
            AuthenticateUser();
            httpClient.DefaultRequestHeaders.Add("Authorization", authResult.CreateAuthorizationHeader());

            httpClient.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
        }

        protected virtual void OnAuthenticated(EventArgs e)
        {
            EventHandler<EventArgs> handler = UserAuthenticated;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<EventArgs> UserAuthenticated;
    }

    public interface IAuthenticator
    {
        Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, string returnUri);
        void ClearCache(string authority);
    }

}
