using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Mobile.Server.Config;

namespace PCLConstruct.Api.Controllers
{
    [MobileAppController]
    

    public class AuthKeyController : ApiController
    {
        [HttpGet, Route("api/AuthKey/")]

        public IHttpActionResult Get()
        {
            return base.StatusCode(System.Net.HttpStatusCode.NotImplemented);

            TelemetryClient tc = new TelemetryClient();
            try
            {
                /*
                To get this page working -- 
                1. download the Phone Factor SDK from the Azure AD MFA Management Portal
                2. add pf_auth.cs to this project
                3. deploy the included certificate to the App Service
                4. Un-comment this code

                */
                //var identity = User.Identity as ClaimsIdentity;
                //// Add call details from the user database.
                //PfAuthParams pfAuthParams = new PfAuthParams();

                //pfAuthParams.Username = identity.Claims.First(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn")).Value;
                
                ////TODO:  Validate that authphone number does not have hyphens.
                ////TODO: Pull the mobile Phone number from the graph for the current user.
                //pfAuthParams.Phone = ConfigurationManager.AppSettings["AuthKeyPhone"];
                //pfAuthParams.Mode = pf_auth.MODE_STANDARD;
                //pfAuthParams.CountryCode = "1";

                //// Specify a client certificate
                //// NOTE: This file contains the private key for the client
                //// certificate. It must be stored with appropriate file
                //// permissions.
                //pfAuthParams.CertFilePath = System.Web.Hosting.HostingEnvironment.MapPath("\\certs\\cert_key.p12");

                //// Perform phone-based authentication
                //int callStatus;
                //int errorId;

                //if (pf_auth.pf_authenticate(pfAuthParams, out callStatus, out errorId))
                //{

                //    //TODO: don't send the tokenresult here it was for debugging.
                //    return new TokenResult(identity);
                //}
                //else
                //{
                //    return base.StatusCode(System.Net.HttpStatusCode.Forbidden);
                //}
            }
            catch (Exception ex)
            {
                tc.TrackException(ex);
                throw ex;
            }
        }
    }

    public class TokenResult : IHttpActionResult
    {

        ClaimsIdentity m_ClaimsID;

        public TokenResult(ClaimsIdentity claimIdentity)
        {
            m_ClaimsID = claimIdentity;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage result = new HttpResponseMessage();
            result.StatusCode = System.Net.HttpStatusCode.OK;

            StringBuilder sb = new StringBuilder();


            m_ClaimsID.Claims.ToList<Claim>().ForEach(c => sb.Append(c.Type));

            StringContent hc = new StringContent(sb.ToString());
            result.Content = hc;

            return Task.FromResult(result);
        }
    }
}