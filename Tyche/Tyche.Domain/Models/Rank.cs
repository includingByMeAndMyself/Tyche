using System.ComponentModel.DataAnnotations;


namespace Tyche.Domain.Models
{
    public enum Rank
    {
        [Display(Name = "Ace")]
        Ace,
        [Display(Name = "2")]
        Two,
        [Display(Name = "3")]
        Three,
        [Display(Name = "4")]
        Four,
        [Display(Name = "5")]
        Five,
        [Display(Name = "6")]
        Six,
        [Display(Name = "7")]
        Seven,
        [Display(Name = "8")]
        Eight,
        [Display(Name = "9")]
        Nine,
        [Display(Name = "10")]
        Ten,
        [Display(Name = "Jack")]
        Jack,
        [Display(Name = "Queen")]
        Queen,
        [Display(Name = "King")]
        King
    }
}
