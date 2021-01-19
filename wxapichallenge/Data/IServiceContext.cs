using System.Collections.Generic;
using System.Threading.Tasks;
using wxapichallenge.Entities;
using wxapichallenge.Models;

namespace wxapichallenge.Data
{
    public interface IServiceContext
    {
         public Task<IEnumerable<Product>> GetProductsAsync();

         public Task<IEnumerable<ShopperHistory>> GetShopperHistoryAsync();

         public Task<float> GetTrolleyTotalAsync(TrolleyItemsForPostDto trolleyItemsForPostDto);
    }
}