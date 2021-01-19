using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wxapichallenge.Controllers;
using wxapichallenge.Data;
using wxapichallenge.Models;
using wxapichallenge.Services;
using Xunit;

namespace wxapichallenge.Tests
{
    public class TrolleyTotalControllerTests
    {
        [Fact]
        public async void GetTrolleyTotal_WhenCalled_ReturnsOkResult()
        {
            //Arrange
            var _serviceContextMock = new Mock<IServiceContext>();
            _serviceContextMock.Setup(a => a.GetTrolleyTotalAsync(GetProductsTrolleyItems())).Returns(CalculateTrolleyTotal());

            IProductRepository _productRepository = new ProductRepository(_serviceContextMock.Object);

            var result = _productRepository.GetTrolleyTotalAsync(GetProductsTrolleyItems());

            TrolleyTotalController _trolleyTotalController = new TrolleyTotalController(_productRepository);

            //Act
            var actionResult = await _trolleyTotalController.GetTrolleyTotal(GetProductsTrolleyItems()) as OkObjectResult;

            //Assert
            Assert.NotNull(actionResult);

        }

        private Task<float> CalculateTrolleyTotal()
        {
            return Task.FromResult(float.Parse("0"));
        }

        public TrolleyItemsForPostDto GetProductsTrolleyItems()
        {
            var jsonData = File.ReadAllText("ProductsTrolleyItems.json");

            TrolleyItemsForPostDto trolleyItemsForPostDto = JsonConvert.DeserializeObject<TrolleyItemsForPostDto>(jsonData);

            return trolleyItemsForPostDto;
        }
    }
}
