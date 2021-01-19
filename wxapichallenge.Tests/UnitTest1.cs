using System;
using wxapichallenge.Controllers;
using Xunit;
using Moq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace wxapichallenge.Tests
{
    public class UnitTest1
    {
        UserController _userController;
        IConfiguration _config;

        [Fact]
        public void GetToken_WhenCalled_ReturnsOkResult()
        {
            // var mockConfSection = new Mock<IConfigurationSection>();
            //         mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "default")])
            //                             .Returns("mock value");

            // Mock<IConfiguration> mock = new Mock<IConfiguration>();
            //     mock.Setup(a => a
            //         .GetSection(It.Is<string>(s=>s == "ConnectionStrings")))
            //         .Returns(mockConfSection.Object);

            var configuration = new Mock<IConfiguration>();
 
            var configurationSectionToken = new Mock<IConfigurationSection>();
            configurationSectionToken.Setup(a => a.Value).Returns("7b8c0ec1-9ea6-4a11-8d2e-0b23759e6ae1");
            
            configuration.Setup(a => a.GetSection("UserToken"))
                            .Returns(configurationSectionToken.Object); 

            var configurationSectionURI = new Mock<IConfigurationSection>();
            configurationSectionURI.Setup(a => a.Value).Returns("https://dev-wooliesx-recruitment.azurewebsites.net/api/resource");
            
            configuration.Setup(a => a.GetSection("ExternalServiceURI"))
                            .Returns(configurationSectionURI.Object); 

            UserController user = new UserController(configuration.Object);
            // Act
            var response = user.GetToken();
            var okResult = response as OkObjectResult;
            var value = okResult.Value as IEnumerable<string>;
            
            Assert.NotEmpty(value);


        }
    }
}
