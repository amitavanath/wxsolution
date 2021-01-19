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
            IEnumerable<Product> productsUnsorted = await _context.GetProductsAsync();

            switch (sortResourceParameters.sortOption.ToString())
            {
                case "Ascending":
                    return productsUnsorted.ToList().OrderBy(product => product.Name);
                case "Descending":
                    return productsUnsorted.ToList().OrderByDescending(product => product.Name);
                case "Low":
                    return productsUnsorted.ToList().OrderBy(product => product.Price);
                case "High":
                    return productsUnsorted.ToList().OrderByDescending(product => product.Price);
                default:
                    return productsUnsorted;
            }
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