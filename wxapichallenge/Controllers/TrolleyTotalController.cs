using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wxapichallenge.Models;
using wxapichallenge.Services;

namespace wxapichallenge.Controllers
{
    [ApiController]
    [Route("api/trolleyTotal")]
    public class TrolleyTotalController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public TrolleyTotalController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // [HttpPost]
        // public async Task<IActionResult> GetTrolleyTotal(TrolleyItemsForPostDto trolleyItemsForPostDto)
        // {
        //     var result = await _productRepository.GetTrolleyTotalAsync(trolleyItemsForPostDto);
        //     return Ok(result);
        // }

        [HttpGet]
        public async Task<IActionResult> GetTrolleyTotal(TrolleyItemsForPostDto trolleyItemsForPostDto)
        {
            var result = await _productRepository.GetTrolleyTotalAsync(trolleyItemsForPostDto);
            return Ok(result);
        }
        
    }
}