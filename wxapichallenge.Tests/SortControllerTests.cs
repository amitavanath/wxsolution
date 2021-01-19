using System;
using wxapichallenge.Controllers;
using Xunit;
using Moq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;
using wxapichallenge.Services;
using wxapichallenge.Data;
using wxapichallenge.ResourceParameters;
using wxapichallenge.Entities;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;

namespace wxapichallenge.Tests
{
    public class SortControllerTests
    {
       

        [Fact]
        public async void GetSortedProducts_WhenCalled_SortOptionAscending_ReturnsNotNullResult()
        {
            //Arrange
            var _serviceContextMock = new Mock<IServiceContext>();
            _serviceContextMock.Setup(a => a.GetProductsAsync()).Returns(GetProductsAsync());

            IProductRepository _productRepository = new ProductRepository(_serviceContextMock.Object);

            SortResourceParameter sortParameter = new SortResourceParameter
            {
                sortOption = SortOption.Ascending
            };

            var result = _productRepository.GetProducts(sortParameter);

            SortController _sortController = new SortController(_productRepository);

            //Act
            var actionResult = await _sortController.GetSortedParams(sortParameter) as OkObjectResult;

            //Assert
            Assert.NotNull(actionResult);


        }

        [Fact]
        public async void GetSortedProducts_WhenCalled_SortOptionDescending_ReturnsNotNullResult()
        {
            //Arrange
            var _serviceContextMock = new Mock<IServiceContext>();
            _serviceContextMock.Setup(a => a.GetProductsAsync()).Returns(GetProductsAsync());

            IProductRepository _productRepository = new ProductRepository(_serviceContextMock.Object);

            SortResourceParameter sortParameter = new SortResourceParameter
            {
                sortOption = SortOption.Descending
            };

            var result = _productRepository.GetProducts(sortParameter);

            SortController _sortController = new SortController(_productRepository);

            //Act
            var actionResult = await _sortController.GetSortedParams(sortParameter) as OkObjectResult;

            //Assert
            Assert.NotNull(actionResult);


        }

        [Fact]
        public async void GetSortedProducts_WhenCalled_SortOptionLow_ReturnsNotNullResult()
        {
            //Arrange
            var _serviceContextMock = new Mock<IServiceContext>();
            _serviceContextMock.Setup(a => a.GetProductsAsync()).Returns(GetProductsAsync());

            IProductRepository _productRepository = new ProductRepository(_serviceContextMock.Object);

            SortResourceParameter sortParameter = new SortResourceParameter
            {
                sortOption = SortOption.Low
            };

            var result = _productRepository.GetProducts(sortParameter);

            SortController _sortController = new SortController(_productRepository);

            //Act
            var actionResult = await _sortController.GetSortedParams(sortParameter) as OkObjectResult;

            //Assert
            Assert.NotNull(actionResult);


        }

        [Fact]
        public async void GetSortedProducts_WhenCalled_SortOptionHigh_ReturnsNotNullResult()
        {
            //Arrange
            var _serviceContextMock = new Mock<IServiceContext>();
            _serviceContextMock.Setup(a => a.GetProductsAsync()).Returns(GetProductsAsync());

            IProductRepository _productRepository = new ProductRepository(_serviceContextMock.Object);

            SortResourceParameter sortParameter = new SortResourceParameter
            {
                sortOption = SortOption.High
            };

            var result = _productRepository.GetProducts(sortParameter);

            SortController _sortController = new SortController(_productRepository);

            //Act
            var actionResult = await _sortController.GetSortedParams(sortParameter) as OkObjectResult;

            //Assert
            Assert.NotNull(actionResult);


        }

        [Fact]
        public async void GetSortedProducts_WhenCalled_SortOptionRecommended_ReturnsNotNullResult()
        {
            //Arrange
            var _serviceContextMock = new Mock<IServiceContext>();
            _serviceContextMock.Setup(a => a.GetProductsAsync()).Returns(GetProductsAsync());

            IProductRepository _productRepository = new ProductRepository(_serviceContextMock.Object);

            SortResourceParameter sortParameter = new SortResourceParameter
            {
                sortOption = SortOption.Recommended
            };

            var result = _productRepository.GetProducts(sortParameter);

            SortController _sortController = new SortController(_productRepository);

            //Act
            var actionResult = await _sortController.GetSortedParams(sortParameter) as OkObjectResult;

            //Assert
            Assert.NotNull(actionResult);


        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
             var jsonData = await File.ReadAllTextAsync("Products.json");

            List<Product> productList = new List<Product>();
            productList = JsonConvert.DeserializeObject<List<Product>>(jsonData);

            return productList;
        }

    }
}
