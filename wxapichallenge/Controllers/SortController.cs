using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// This API provides a range of sorting options.
        /// This call "products" resource to get a list of available products.
        /// This endpoint accepts a query string parameter called "sortOption"
        /// with strings Low, High, Ascending, Descending and Recommended.
        /// </summary>
        /// <param name="sortOption">Low, High, Ascending, Descending, Recommended</param>
        [HttpGet]
        public Task<IActionResult> GetSortedParams([FromQuery] SortResourceParameter 
            sortResourceParameter) => sortResourceParameter.sortOption.ToString() == "Recommended" ?
            GetRecommendedProducts(sortResourceParameter) : GetSortedProducts(sortResourceParameter);
        
        private async Task<IActionResult> GetSortedProducts(SortResourceParameter sortResourceParameter)
        {
            var products = await _productRepository.GetProductsAsync(sortResourceParameter);
            return Ok(products);
        }

        private async Task<IActionResult> GetRecommendedProducts(SortResourceParameter sortResourceParameter)
        {
            var shopperHistories = await _productRepository.GetPopularProductsFromShopperHistoriesAsync();
            return Ok(shopperHistories);
        }
    }
}