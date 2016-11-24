using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using PCLConstruct.Api.DataObjects;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;
using System.IdentityModel.Tokens;

namespace PCLConstruct.Api
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);
            

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            //if (string.IsNullOrEmpty(settings.HostName))
            //{
            //    app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
            //    {
            //        // This middleware is intended to be used locally for debugging. By default, HostName will
            //        // only have a value when running in an App Service application.
            //        SigningKey = ConfigurationManager.AppSettings["SigningKey"],
            //        ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
            //        ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
            //        TokenHandler = config.GetAppServiceTokenHandler()
            //    });
            //}

            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
              new WindowsAzureActiveDirectoryBearerAuthenticationOptions
              {
                  Tenant = ConfigurationManager.AppSettings["ida:Tenant"],
                  TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidAudience = ConfigurationManager.AppSettings["ida:Audience"]
                  },
              });

            app.UseWebApi(config);
        }
    }

 
}

