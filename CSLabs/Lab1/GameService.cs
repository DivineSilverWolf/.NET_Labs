using Microsoft.Extensions.Hosting;

namespace Lab1
{
    public class GameService: IHostedService{
        private int _count;
        private readonly Game _game;
    
        public GameService(Game game, int count)
        {
            _game = game;
            _count = count;
        }

        private void StartGame() {  
            var win = 0;
            for (var i = 0; i < _count; i++)
            {
                try
                {
                    _game.DealTheDeckForPlayers();
                    win += _game.PlayResult() ? 1 : 0;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.InnerException?.Message);
                    _count = ++i;
                    break;
                }
            }

            Console.WriteLine((double) win / _count * 100 + "%");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(StartGame, cancellationToken);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}