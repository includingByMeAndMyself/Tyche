using Client.CLI.Interfaces;
using System;
using System.Linq;


namespace Client.CLI
{
    internal partial class Client
    {
        private IDeckHttpClient _deckHttpClient;

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
                Console.WriteLine("Select a menu item:" +
                    "\n\t1) Create named deck" +
                    "\n\t2) Getting a deck of cards by name" +
                    "\n\t3) Get a list of deck names" +
                    "\n\t4) Getting all decks of cards" +
                    "\n\t5) Deleting all deck of cards" +
                    "\n\t6) Deleting deck of cards by name" +
                    "\n\t7) Shuffle dekcs of cards in the selected way");


                userAnswer = Console.ReadLine();

                switch (userAnswer)
                {
                    case "1":
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
                }

                Console.WriteLine("Continue? (y/n)");
                userAnswer = Console.ReadLine();

                isUserContinue = userAnswer.ToLower() == "y";

            } while (isUserContinue);
        }
    }
}
