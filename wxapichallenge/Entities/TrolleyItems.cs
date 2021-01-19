using System.Collections.Generic;

namespace wxapichallenge.Entities
{
    public class TrolleyItems
    {
        public ICollection<Product> Products { get; set; }
            = new List<Product>();

        public ICollection<ProductQuantities> Quantities { get; set; }
            = new List<ProductQuantities>();

        public ICollection<SpecialProducts> Specials { get; set; }
            = new List<SpecialProducts>();
    }
}