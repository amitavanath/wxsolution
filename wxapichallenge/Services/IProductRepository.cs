using System.Collections.Generic;
using System.Threading.Tasks;
using wxapichallenge.Entities;
using wxapichallenge.Models;
using wxapichallenge.ResourceParameters;

namespace wxapichallenge.Services
{
    public interface IProductRepository
    {
         public Task<IEnumerable<Product>> GetProducts(SortResourceParameter sortResourceParameters);

         public Task<IEnumerable<ShopperHistory>> GetShopperHistories();

         public Task<float> GetTrolleyTotalAsync(TrolleyItemsForPostDto trolleyItemsForPostDto);

        public Task<IEnumerable<Product>> GetPopularProductsFromShopperHistories();
    }
}