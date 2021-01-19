using System.Collections.Generic;

namespace wxapichallenge.Models
{
    public class SpecialProductsForPostDto
    {
        public ICollection<ProductQuantitiesForPostDto> Quantities { get; set; }
            = new List<ProductQuantitiesForPostDto>();
        
        public int Total { get; set; }
    }
}