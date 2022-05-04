using Client.CLI.Infrastructure;
using Client.CLI.Interfaces;
using Client.CLI.Models;
using System;
using System.Linq;


namespace Client.CLI
{
    internal partial class Client
    {
        private IDeckHttpClient _deckHttpClient;
        private const int WIDTH_CONSOLE = 120;

        public Client(IDeckHttpClient deckHttpClient)
        {
            _deckHttpClient = deckHttpClient;
        }

        internal void Start()
        {
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
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
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
            Console.WriteLine();
            Console.Write("\tEnter Decks name: ");

            var name = Console.ReadLine();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tDecks Type:" +
                "\r\n\t\"52\" if you want create StandartDeck = 52 cards " +
                "\r\n\t\"36\" if you want create SmallDeck = 36 cards");
            Console.ResetColor();
            Console.Write("\r\n\tEnter Decks Type: ");
            var type = Console.ReadLine();
            
            var deckType = type.ToDeckType();

            var response = _deckHttpClient.CreateNamedDeckAsync(name, deckType);
            Console.WriteLine("\r\n\t" + response.Result);
        }

        private static void PrintLine()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('_', WIDTH_CONSOLE));
            Console.ResetColor();
            Console.WriteLine();
        }

        private static void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t1 - Create named deck;" +
                    "\n\t2 - Getting a deck of cards by name;" +
                    "\n\t3 - Get a list of deck names;" +
                    "\n\t4 - Getting all decks of cards;" +
                    "\n\t5 - Deleting all deck of cards;" +
                    "\n\t6 - Deleting deck of cards by name;" +
                    "\n\t7 - Shuffle named deck in the selected way;" +
                    "\n\t8 - Exit;");
            Console.ResetColor();
        }
    }
}
