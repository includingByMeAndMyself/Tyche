using System.ComponentModel.DataAnnotations;


namespace Tyche.API.Models
{
    public class ShuffleRequest
    {
        [Range(1, 2)]
        public int ShuffleOption { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name length must be in the family from {2}-{1} characters")]
        public string Name { get; set; }
    }
}
