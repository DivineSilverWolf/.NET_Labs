using Contracts;
using MassTransit;

namespace Lab6_MarkWeb.Consumers;

public class NumberConsumer : IConsumer<NumberMessage>
{
    public Task Consume(ConsumeContext<NumberMessage> context)
    {
        if (context.Message.Signature == "elon") return Task.CompletedTask;
        ElonStats.Color = ElonStats.Cards[context.Message.Number].Color; 
        //ResourceLock.ResourceAvailable();
        context.Publish(new OkPlayer());
        return Task.CompletedTask;
    }
}