using Contracts;
using Lab6_Gods.HttpClientPackage;
using MassTransit;

namespace Lab6_Gods.Consumers;

public class GetterConsumer : IConsumer<SenderCompleted>
{
    private readonly ColorApiClient _colorApiClient;
    private readonly int _elonPort;
    private readonly int _markPort;
    public GetterConsumer(ColorApiClient colorApiClient, int elonPort, int markPort)
    {
        _colorApiClient = colorApiClient;
        _elonPort = elonPort;
        _markPort = markPort;
    }
    public async Task Consume(ConsumeContext<SenderCompleted> context)
    {
        await DataControl.Getter(_colorApiClient, _elonPort, _markPort);
        await context.Publish(new GetterCompleted()); }
}