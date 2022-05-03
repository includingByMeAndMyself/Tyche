using System.ComponentModel.DataAnnotations;


namespace Tyche.API.Models
{
    public class ShuffleRequest
    {
        [Range(1, 2)]
        public int SortOption { get; set; }
    }
}
