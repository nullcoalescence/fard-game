using fardgame.models;
using fardgame.core;
using fardgame.core.Services.Interfaces;

namespace fardgame.cli.Services
{
    internal class GameLoopService
    {
        private readonly ICardBuilderService _cardBuilderService;

        public GameLoopService(ICardBuilderService cardBuilderService)
        {
            _cardBuilderService = cardBuilderService;
        }

        public void StartGameLoop()
        {
            // Start
            Console.WriteLine("Let's draw your starting hand of 5 cards");
            var startingHand = new List<Card>();

            for (int i = 0; i < 5; i++)
            {
                startingHand.Add(_cardBuilderService.CreateRandomCard());
            }

            Console.WriteLine("Your starting hand looks like:");
            startingHand.ForEach(card => Console.WriteLine(card.ToString()));

            while (true)
            {
                Console.WriteLine("game loop test - press enter to continue looping....");
                Console.ReadLine();
            }
        }
    }
}
