using System.Collections.Generic;
using System.Threading.Tasks;
using wxapichallenge.Entities;
using wxapichallenge.Models;
using wxapichallenge.ResourceParameters;

namespace wxapichallenge.Services
{
    public interface IProductRepository
    {
         public Task<IEnumerable<Product>> GetProductsAsync(SortResourceParameter sortResourceParameters);

         public Task<float> GetTrolleyTotalAsync(TrolleyItemsForPostDto trolleyItemsForPostDto);

        public Task<IEnumerable<Product>> GetPopularProductsFromShopperHistoriesAsync();
    }
}