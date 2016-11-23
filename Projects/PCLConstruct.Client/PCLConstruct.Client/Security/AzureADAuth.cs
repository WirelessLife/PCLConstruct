using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using System.Net.Http.Headers;

namespace PCLConstruct.Client.Security
{
    public class AzureADAuth
    {
        public static string clientId = "f37dac5f-fe14-442f-99aa-18ee1fa0f46b"; //"2a2a6954-856e-4dea-ab07-3cefffdfc65c"; 
        public static string authority = "https://login.windows.net/common";
        public static string returnUri = "https://pcl-dev-pclconstruct-api.azurewebsites.net/.auth/login/done";
        private const string graphResourceUri = "https://graph.windows.net";
        public AuthenticationResult authResult = null;

        /// <summary>
        /// This given and the family name for the authenticated user
        /// </summary>
        public string UserName { get; set; }

        public async void AuthenticateUser()
        {
            var auth = DependencyService.Get<IAuthenticator>();
            authResult = await auth.Authenticate(authority, graphResourceUri, clientId, returnUri);
            this.UserName = authResult.UserInfo.GivenName + " " + authResult.UserInfo.FamilyName;
            OnAuthenticated(new EventArgs());
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
