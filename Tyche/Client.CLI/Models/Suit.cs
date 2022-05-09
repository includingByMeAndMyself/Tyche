using Client.CLI.Infrastructure;


namespace Client.CLI.Models
{
    public enum Suit
    {
        [Display(Name = "Пики")]
        Spades,
        [Display(Name = "Трефы")]
        Clubs,
        [Display(Name = "Червы")]
        Hearts,
        [Display(Name = "Бубны")]
        Diamonds
    }
}
