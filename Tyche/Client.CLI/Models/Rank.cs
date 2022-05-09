using Client.CLI.Infrastructure;


namespace Client.CLI.Models
{
    public enum Rank
    {
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
        [Display(Name = "Валет")]
        Jack,
        [Display(Name = "Дама")]
        Queen,
        [Display(Name = "Король")]
        King,
        [Display(Name = "Туз")]
        Ace
    }
}
