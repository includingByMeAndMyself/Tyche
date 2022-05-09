using Client.CLI.Infrastructure;
using System;
using System.Text;

namespace Client.CLI.Models
{
    public class Card
    {
        public int SequenceNumber { get; private set; }

        public ConsoleColor Color { get; private set; }

        public char UnicodeSign { get; private set; }

        public Rank Rank { get; }

        public Suit Suit { get; }

        public Card(Rank rank, Suit suit, int sequenceNumber)
        {
            if (suit == Suit.Hearts || suit == Suit.Diamonds)
                Color = ConsoleColor.Red;
            else
                Color = ConsoleColor.White;

            Rank = rank;
            Suit = suit;

            SequenceNumber = sequenceNumber;

            UnicodeSign = SetUnicodeSign();
        }

        private char SetUnicodeSign()
        {
            switch (Suit)
            {
                case Suit.Spades:
                    return '\u2660';
                case Suit.Clubs:
                    return '\u2663';
                case Suit.Hearts:
                    return '\u2665';
                case Suit.Diamonds:
                    return '\u2666';
                default:
                    return '-';
            }
        }

        public void ShowCard()
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.ForegroundColor = this.Color;

            string rank = Rank.GetDisplayName();

            string output = $"{UnicodeSign}{rank}";

            if (output.Length < 9)
            {
                output = String.Concat(output, new string(' ', 9 - output.Length));
            }

            Console.WriteLine($"\t[{output}]");
        }

        public override string ToString()
        {
            string rank = Rank.GetDisplayName();

            var result = $"{Suit}-{rank}";

            return result;
        }
    }
}
