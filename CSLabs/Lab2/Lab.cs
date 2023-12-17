using Lab1;
using Lab1.God;
using Lab1.Players;
using Lab1.Strategy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lab2 
{
    public static class Lab 
    {
        private static readonly string ParentDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddHostedService<GameService>(p =>
                    {
                        var elon = new Elon(new StrategyNumberOne());
                        var mark = new Mark(new StrategyNumberOne());

                        var gameGuidedByTheGod = new GameGuidedByTheGod(2, 36);
                        var count = int.Parse(args[1]);
                        
                        var configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile(ParentDirectory + "appsettings.json")
                            .Build();
                        
                        var game = args[0] switch
                        {
                            "writeDB" => new Game(elon, mark, gameGuidedByTheGod, configuration),
                            "readDB" => new GameDataBase(elon, mark, configuration, 100),
                            "noDB" => new Game(elon, mark, gameGuidedByTheGod),
                            _ => throw new ArgumentException("Invalid argument")
                        };
                        return new GameService(game, count);
                    });
                });
        }
    }
}