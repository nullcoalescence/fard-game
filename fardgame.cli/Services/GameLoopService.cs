using fardgame.models;

namespace fardgame.cli.Services
{
    internal class GameLoopService
    {
        public GameLoopService() { }

        public void StartGameLoop()
        {
            Console.WriteLine("Game loop started");
            while (true)
            {
                Console.WriteLine("game loop test - press enter to continue looping....");
                Console.ReadLine();
            }
        }
    }
}
