using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace wxapichallenge.ResourceParameters
{
    public enum SortOption
    {
        Low,
        High,
        Ascending,
        Descending,
        Recommended
    }

    public class SortResourceParameter
    {
        [BindRequired]
        public SortOption sortOption {get; set;}
    }
}