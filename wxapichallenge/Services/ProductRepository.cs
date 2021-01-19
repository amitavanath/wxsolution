using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wxapichallenge.Data;
using wxapichallenge.Entities;
using wxapichallenge.Models;
using wxapichallenge.ResourceParameters;

namespace wxapichallenge.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly IServiceContext _context;

        public ProductRepository(IServiceContext context) => _context = context
            ?? throw new System.ArgumentNullException(nameof(context));

        public async Task<IEnumerable<Product>> GetProducts(SortResourceParameter sortResourceParameters)
        {
            IEnumerable<Product> gainStrings = await _context.GetProductsAsync();
  
            if(sortResourceParameters.sortOption.ToString() == "Ascending")
            {
                return gainStrings.ToList().OrderBy(product => product.Name);
            }
            else if(sortResourceParameters.sortOption.ToString() == "Descending")
            {
                return gainStrings.ToList().OrderByDescending(product => product.Name);
            }
            else if(sortResourceParameters.sortOption.ToString() == "Low")
            {
                return gainStrings.ToList().OrderBy(product => product.Price);
            }
            else if(sortResourceParameters.sortOption.ToString() == "High")
            {
                return gainStrings.ToList().OrderByDescending(product => product.Price);
            }

            return gainStrings;
            
        }

        public Task<IEnumerable<ShopperHistory>> GetShopperHistories()
        {
            return _context.GetShopperHistoryAsync();
        }

        public Task<float> GetTrolleyTotalAsync(TrolleyItemsForPostDto trolleyItemsForPostDto)
        {
            return _context.GetTrolleyTotalAsync(trolleyItemsForPostDto);
        }
    }
}