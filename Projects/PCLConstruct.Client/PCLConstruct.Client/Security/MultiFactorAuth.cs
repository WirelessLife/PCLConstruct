using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace PCLConstruct.Client.Security
{
    public class MultiFactorAuth
    {
        public bool MfAuthenticateUser(AzureADAuth azureauth)
        {
            HttpClient httpClient = new HttpClient();
            Uri _uri = new Uri("http://pcl-dev-pclconstruct-api.azurewebsites.net/api/authkey");

            azureauth.BuildAuthHeader(ref httpClient);
            var response = httpClient.GetAsync(_uri);
            var responseBody = response.Result.Content.ReadAsStringAsync();

            return response.Result.StatusCode == HttpStatusCode.OK;
        }
    }
}
