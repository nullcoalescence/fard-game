using fardgame.cli.Services;
using fardgame.core.Services;
using fardgame.core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace fardgame.cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            // =============================
            // Add services
            // =============================

            // Singletons
            builder.Services.AddSingleton<GameLoopService>();

            // Scoped
            builder.Services.AddScoped<ICardBuilderService, CardBuilderService>();

            // =============================
            // Configure the application lifetime
            // =============================
            using (IHost host = builder.Build())
            {
                var lifetime = host.Services.GetRequiredService<IHostApplicationLifetime>();

                lifetime.ApplicationStarted.Register(() =>
                {
                    Console.WriteLine("Started");

                    // Intro text
                    Console.WriteLine("** FardGame CLI **");
                    Console.WriteLine($"Today's Date: {DateTime.Now.ToShortDateString()}");
                    Console.WriteLine($"Environment: {Environment.GetEnvironmentVariable("environment") ?? "!! none set"}");
                    Console.WriteLine("******************");
                    Console.WriteLine();

                    // Inject the game loop singleton and start it
                    using (var scope = host.Services.CreateScope())
                    {
                        var gameLoop = scope.ServiceProvider.GetRequiredService<GameLoopService>();
                        gameLoop.StartGameLoop();
                    }
                });

                lifetime.ApplicationStopping.Register(() =>
                {
                    Console.WriteLine("Stopping");
                });

                lifetime.ApplicationStopped.Register(() =>
                {
                    Console.WriteLine("Stopped");
                });

                host.Start();
                host.WaitForShutdown();
            }
        }
    }
}