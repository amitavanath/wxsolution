using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wxapichallenge.Entities;
using wxapichallenge.ResourceParameters;
using wxapichallenge.Services;

namespace wxapichallenge.Controllers
{
    [ApiController]
    [Route("api/sort")]
    public class SortController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public SortController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public Task<IActionResult> GetSortedParams([FromQuery] SortResourceParameter 
            sortResourceParameter) => sortResourceParameter.sortOption.ToString() == "Recommended" ?
            GetRecommendedProducts(sortResourceParameter) : GetSortedProducts(sortResourceParameter);
        
        private async Task<IActionResult> GetSortedProducts(SortResourceParameter sortResourceParameter)
        {
            var products = await _productRepository.GetProducts(sortResourceParameter);
            return Ok(products);
        }

        private async Task<IActionResult> GetRecommendedProducts(SortResourceParameter 
            sortResourceParameter)
        {
            var shopperHistories = await _productRepository.GetShopperHistories();
            return Ok(shopperHistories);
        }
    }
}