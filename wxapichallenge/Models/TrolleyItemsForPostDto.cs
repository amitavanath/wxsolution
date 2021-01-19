using System.Collections.Generic;

namespace wxapichallenge.Models
{
    public class TrolleyItemsForPostDto
    {
        //public int CustomerId { get; set; }

        public ICollection<ProductForPostDto> Products { get; set; }
            = new List<ProductForPostDto>();
        public ICollection<SpecialProductsForPostDto> Specials { get; set; }
            = new List<SpecialProductsForPostDto>();
        public ICollection<ProductQuantitiesForPostDto> Quantities { get; set; }
            = new List<ProductQuantitiesForPostDto>();
    }
}