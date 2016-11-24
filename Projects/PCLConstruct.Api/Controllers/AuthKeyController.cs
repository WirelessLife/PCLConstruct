using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;

namespace PCLConstruct.Api.Controllers
{
    [MobileAppController]

    public class AuthKeyController : ApiController
    {
        [HttpPost, Route("api/AuthKey/")]
       
        public IHttpActionResult Post()
        {
            var temp = User.Identity as ClaimsIdentity;
           // Add call details from the user database.
            PfAuthParams pfAuthParams = new PfAuthParams();
            pfAuthParams.Username = "";
            pfAuthParams.Phone = ConfigurationManager.AppSettings["AuthKeyPhone"];
            pfAuthParams.Mode = pf_auth.MODE_STANDARD;
            pfAuthParams.CountryCode = "1";

            // Specify a client certificate
            // NOTE: This file contains the private key for the client
            // certificate. It must be stored with appropriate file
            // permissions.
            pfAuthParams.CertFilePath = @"D:\Development\PCLConstructPOC\Projects\PCLConstruct.Api\Helpers\cert_key.p12";

            // Perform phone-based authentication
            int callStatus;
            int errorId;

            if (pf_auth.pf_authenticate(pfAuthParams, out callStatus, out errorId))
            {
                return Ok();
            }
            else
            {
                return base.StatusCode(System.Net.HttpStatusCode.Forbidden);
            }


        }
    }
}