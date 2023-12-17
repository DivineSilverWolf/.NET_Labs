using Contracts;
using Lab6_Gods.BusPackage;
using Lab6_Gods.DataBaseControl;
using Lab6_Gods.HttpClientPackage;
using MassTransit;

namespace Lab6_Gods
{
    internal class GodsServer
    {
        private readonly ColorApiClient _colorApiClient;

        public GodsServer(ColorApiClient colorApiClient)
        {
            _colorApiClient = colorApiClient;
        }

        public async Task RunExperiments(int elonPort, int markPort, string urlServer, string name, string password, string urlElon, string urlMark, int totalExperiments)
        {
            DataControl.TotalExperiments = totalExperiments;
            var dbInfo = LoaderDb.LoadDb(1);
            var busControl = BusControl.LoadBusRabbitMq(urlServer, name, 
                password, urlElon, urlMark, elonPort, markPort, _colorApiClient, dbInfo);
            BusControl.StartBusControl(busControl);
            Console.WriteLine("Gods is running experiments...");
            await busControl.Publish(new GetterCompleted());
            DataControl.Semaphore.WaitOne();

            BusControl.StopBusControl(busControl);
        }
        
        
    }
}