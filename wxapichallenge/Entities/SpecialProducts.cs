using System.Collections.Generic;

namespace wxapichallenge.Entities
{
    public class SpecialProducts
    {
        public ICollection<ProductQuantities> Quantities { get; set; }
            = new List<ProductQuantities>();
        
        public float Total { get; set; }
    }
}