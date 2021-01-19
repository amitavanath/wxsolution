using System.Collections.Generic;

namespace wxapichallenge.Entities
{
    public class ShopperHistory
    {
        public int CustomerId { get; set; }

        public ICollection<Product> Products { get; set; }
            = new List<Product>();
    }
}