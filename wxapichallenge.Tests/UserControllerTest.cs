using System;
using wxapichallenge.Controllers;
using Xunit;
using Moq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;

namespace wxapichallenge.Tests
{
    public class UserControllerTest
    {
        UserController _userController;
        IConfiguration _config;

        [Fact]
        public void GetToken_WhenCalled_ReturnsOkResult()
        {
            var configuration = new Mock<IConfiguration>();
 
            var configurationSectionToken = new Mock<IConfigurationSection>();
            configurationSectionToken.Setup(a => a.Value).Returns("7b8c0ec1-9ea6-4a11-8d2e-0b23759e6ae1");

            var configurationSectionUserName = new Mock<IConfigurationSection>();
            configurationSectionUserName.Setup(a => a.Value).Returns("Amitava Nath");

            configuration.Setup(a => a.GetSection("UserToken"))
                            .Returns(configurationSectionToken.Object);

            configuration.Setup(a => a.GetSection("UserName"))
                            .Returns(configurationSectionUserName.Object);


            UserController user = new UserController(configuration.Object);
            
            var response = user.GetToken();
            var okResult = response as OkObjectResult;
            var name = okResult.Value.GetType().GetProperty("name").GetValue(okResult.Value);
            var token = okResult.Value.GetType().GetProperty("token").GetValue(okResult.Value);

            Assert.Equal("Amitava Nath", name.ToString());
            Assert.Equal("7b8c0ec1-9ea6-4a11-8d2e-0b23759e6ae1", token.ToString());


        }
    }
}
