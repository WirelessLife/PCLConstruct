﻿using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace PCLConstruct.Api.Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthenticationContext ctx = new AuthenticationContext("https://login.windows.net/common");

            var result = ctx.AcquireTokenAsync("", 
                "", 
                new Uri("https://tylermobile.azurewebsites.net/.auth/login/done"), new PlatformParameters(PromptBehavior.Auto)).Result;

            var tok = result.AccessToken;

            var client = new MobileServiceClient("https://tylermobile.azurewebsites.net");
            JObject payload = new JObject();

            payload["access_token"] = tok;
            var user = client.LoginAsync(MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory, payload).Result;

            var forms = client.GetTable("form");

            //var key = client.InvokeApiAsync("AuthKey", HttpMethod.Get, new Dictionary<string, string>()).Result;


        }
    }
}
