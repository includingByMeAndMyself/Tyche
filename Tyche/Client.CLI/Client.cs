using Client.CLI.Infrastructure;
using Client.CLI.Interfaces;
using System;


namespace Client.CLI
{
    internal partial class Client
    {
        private IDeckHttpClient _deckHttpClient;
        private const int WIDTH_CONSOLE = 120;
        private const int HIGHT_CONSOLE = 30;

        public Client(IDeckHttpClient deckHttpClient)
        {
            _deckHttpClient = deckHttpClient;
            Console.SetWindowSize(WIDTH_CONSOLE, HIGHT_CONSOLE);

        }

        internal void Start()
        {
            Console.Title= "Tyche Client";
            Console.WriteLine("Client started");

            var isUserContinue = true;
            string userAnswer;

            do
            {
                Console.Clear();

                PrintLine();
                PrintMenu();
                PrintLine();

                Console.Write("\n\tSelect a menu item: ");

                userAnswer = Console.ReadLine();

                Console.Clear();

                switch (userAnswer)
                {
                    case "1":
                        CreateNamedDeckAsync();
                        break;
                    case "2":
                        GetDeckByNameAsync();
                        break;
                    case "3":
                        GetCreatedDecksNamesAsync();
                        break;
                    case "4":
                        GetDecksAsync();
                        break;
                    case "5":
                        DeleteDecksAsync();
                        break;
                    case "6":
                        DeleteDeckByNameAsync();
                        break;
                    case "7":
                        ShuffleDeckByNameAsync();
                        break;
                    case "8":
                        break;
                    default :  
                        continue;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\tAre you sure you want to quit? (y/n): ");
                userAnswer = Console.ReadLine();
                Console.ResetColor();

                isUserContinue = userAnswer.ToLower() == "n";
                
            } while (isUserContinue);
        }

        public void CreateNamedDeckAsync()
        {
            var mesg = "\tEnter Decks name: ";
            PrintLineGreen(mesg);

            var name = Console.ReadLine();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tDecks Type:" +
                "\r\n\t\"52\" if you want create StandartDeck = 52 cards " +
                "\r\n\t\"36\" if you want create SmallDeck = 36 cards");
            Console.Write("\r\n\tEnter Decks Type: ");
            Console.ResetColor();
            var type = Console.ReadLine();
            
            var deckType = type.ToDeckType();

            var response = _deckHttpClient.CreateNamedDeckAsync(name, deckType);

            if(response.Result != null)
                Console.WriteLine("\r\n\t" + response.Result);
        }

        public void GetCreatedDecksNamesAsync()
        {
            Console.WriteLine();

            var response = _deckHttpClient.GetCreatedDecksNamesAsync();
            var count = 1;

            if(response.Result != null)
            {
                var mesg = "\r\n\tNames of deck(s):";
                PrintGreen(mesg);

                foreach (var name in response.Result)
                {
                    Console.WriteLine($"\r\n\t{count}) " + name);
                    count++;
                }
            }
            else
            {
                Console.WriteLine("\r\n\tNo decks of cards created");
            }
        }

        public void GetDeckByNameAsync()
        {
            var mesg = "\tEnter Decks name: ";
            PrintLineGreen(mesg);

            var name = Console.ReadLine();

            var response = _deckHttpClient.GetDeckByNameAsync(name);
            if (response.Result != null)
            {
                response.Result.ShowDeck();
            }
            else
            {
                Console.WriteLine($"\r\n\tNo deck of cards whit name {name} created");
            }
        }

        public void GetDecksAsync()
        {
            var response = _deckHttpClient.GetDecksAsync();

            if (response.Result != null)
            {
                foreach (var deck in response.Result)
                {
                    deck.ShowDeck();
                } 
            }
            else
            {
                Console.WriteLine($"\r\n\tHave no decks of cards");
            }
        }

        public void DeleteDeckByNameAsync()
        {
            var mesg = "\tEnter Decks name: ";
            PrintLineGreen(mesg);
            var name = Console.ReadLine();

            var response = _deckHttpClient.DeleteDeckByNameAsync(name);

            if (response.Result != null)
                Console.WriteLine("\r\n\t" + response.Result);
        }

        public void DeleteDecksAsync()
        {
            var response = _deckHttpClient.DeleteDecksAsync();
            if (response.Result != null)
                Console.WriteLine("\r\n\t" + response.Result);
        }

        public void ShuffleDeckByNameAsync()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\tEnter Decks name: ");
            Console.ResetColor();

            var name = Console.ReadLine();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tShuffle Option:" +
                "\r\n\t\"1\" if you want to shuffle a deck of cards" +
                "\r\n\t\"2\" if you want to shuffle the deck of cards in order");
            Console.Write("\r\n\tEnter Shuffle Option: ");
            Console.ResetColor();
            var type = Console.ReadLine();

            var shuffleType = type.ToShuffleOption();

            var response = _deckHttpClient.ShuffleDeckByNameAsync(shuffleType, name);

            if (response.Result != null)
                Console.WriteLine("\r\n\t" + response.Result);
        }

        private static void PrintLineGreen(string mesg)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(mesg);
            Console.ResetColor();
        }

        private static void PrintGreen(string mesg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\r\n\tNames of deck(s):");
            Console.ResetColor();
        }

        private static void PrintLine()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string(' ', WIDTH_CONSOLE));
            Console.ResetColor();
            Console.WriteLine();
        }

        private static void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t1 - Create named deck;" +
                    "\n\t2 - Getting a deck of cards by name;" +
                    "\n\t3 - Get list of deck names;" +
                    "\n\t4 - Getting all decks of cards;" +
                    "\n\t5 - Deleting all deck of cards;" +
                    "\n\t6 - Deleting deck of cards by name;" +
                    "\n\t7 - Shuffle named deck in the selected way;" +
                    "\n\t8 - Exit;");
            Console.ResetColor();
        }
    }
}
