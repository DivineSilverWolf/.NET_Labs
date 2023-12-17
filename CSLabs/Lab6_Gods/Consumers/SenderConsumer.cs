using Contracts;
using Lab6_Gods.BusPackage;
using Lab6_Gods.DataBaseControl;
using MassTransit;

namespace Lab6_Gods.Consumers;

public class SenderConsumer: IConsumer<GetterCompleted>
{
    private readonly DbInfo _dbInfo;
    private readonly string _url1;
    private readonly string _url2;
    
    public SenderConsumer(DbInfo dbInfo, string url1, string url2)
    {
        _dbInfo = dbInfo;
        _url1 = url1;
        _url2 = url2;
    }

    public async Task Consume(ConsumeContext<GetterCompleted> context)
    {
        var (elonEndpoint, markEndpoint) = LoaderEndPoints.LoadEndPointForTwoPlayers(context, _url1, _url2).Result;
        await DataControl.Sender(_dbInfo, elonEndpoint, markEndpoint);
    }
}