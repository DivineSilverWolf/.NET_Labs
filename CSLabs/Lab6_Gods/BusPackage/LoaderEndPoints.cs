using MassTransit;

namespace Lab6_Gods.BusPackage;

public class LoaderEndPoints
{
    public static async Task<(ISendEndpoint, ISendEndpoint)> LoadEndPointForTwoPlayers(ConsumeContext context, string url1, string url2)
    {
        return (await context.GetSendEndpoint(new Uri(url1)), await context.GetSendEndpoint(new Uri(url2)));
    }
        
}