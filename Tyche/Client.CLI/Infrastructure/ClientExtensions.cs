using Client.CLI.Models;
using System;


namespace Client.CLI.Infrastructure
{
    public static class ClientExtensions
    {
        public static DeckType ToDeckType(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return DeckType.SmalDeck;

            if (int.TryParse(value, out var res))
            {
                if (res == 36)
                {
                    Enum.TryParse(value, out DeckType smalDeck);
                    return smalDeck;
                }
                else if (res == 52)
                {
                    Enum.TryParse(value, out DeckType standartDeck);
                    return standartDeck;
                }
            }
            return DeckType.SmalDeck;
        }

        public static ShuffleOption ToShuffleOption(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return ShuffleOption.InOrder;

            if (int.TryParse(value, out var res))
            {
                if (res == 1)
                {
                    Enum.TryParse(value, out ShuffleOption simpleShuffle);
                    return simpleShuffle;
                }
                else if (res == 2)
                {
                    Enum.TryParse(value, out ShuffleOption inOrder);
                    return inOrder;
                }
            }
            return ShuffleOption.InOrder;
        }
    }
}
