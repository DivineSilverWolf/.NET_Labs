using Autofac;
using Lab6_Gods.Consumers;
using Lab6_Gods.DataBaseControl;
using Lab6_Gods.HttpClientPackage;
using MassTransit;

namespace Lab6_Gods.BusPackage;

public static class BusControl
{
    public static IBusControl LoadBusRabbitMq(string url, string name, string password, string urlElon, string urlMark, int portElon, int portMark, ColorApiClient client, DbInfo dbInfo)
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterInstance(new GetterConsumer(client, portElon, portMark)).As<GetterConsumer>();
        containerBuilder.RegisterInstance(new SenderConsumer(dbInfo, urlElon, urlMark)).As<SenderConsumer>();
        var container = containerBuilder.Build();
    
        var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host(new Uri(url), h =>
            {
                h.Username(name);
                h.Password(password);
            });
            cfg.ReceiveEndpoint(ep =>
            {
                ep.Consumer<ReadyPlayersConsumer>();
                ep.Consumer(() => container.Resolve<GetterConsumer>());
                ep.Consumer(() => container.Resolve<SenderConsumer>());
            });
        });
        return busControl;
    }

    public static void StartBusControl(IBusControl busControl)
    {
        busControl.Start();
    }
    public static void StopBusControl(IBusControl busControl)
    {
        busControl.Stop();
    }
}