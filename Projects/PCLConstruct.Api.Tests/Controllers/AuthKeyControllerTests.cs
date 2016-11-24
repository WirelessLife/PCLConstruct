using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCLConstruct.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace PCLConstruct.Api.Controllers.Tests
{
    [TestClass()]
    public class AuthKeyControllerTests
    {
        [TestMethod()]
        public async Task PostTest()
        {            
            AuthenticationContext context = new AuthenticationContext("https://login.windows.net/common");            

            AuthKeyController sut = new AuthKeyController();
            //var result = sut.Post();
        }
    }
}