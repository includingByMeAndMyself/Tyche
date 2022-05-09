using System.ComponentModel.DataAnnotations;
using Tyche.Domain.Models;

namespace Tyche.API.Models
{
    public class DeckRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name length must be in the family from {2}-{1} characters")]
        public string Name { get; set; }

        [Required]
        public DeckType DeckType { get; set; }
    }
}
