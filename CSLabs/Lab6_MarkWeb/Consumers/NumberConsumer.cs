using Contracts;
using MassTransit;

namespace Lab6_MarkWeb.Consumers;

public class NumberConsumer : IConsumer<NumberMessage>
{
    public Task Consume(ConsumeContext<NumberMessage> context)
    {
        if (context.Message.Signature == "zuck") return Task.CompletedTask;
        //Console.WriteLine($"This is the message from {context.Message.Signature}. The number is {context.Message.Number}");
        MarkStats.Color = MarkStats.Cards[context.Message.Number].Color;
        
       // ResourceLock.ResourceAvailable();
        context.Publish(new OkPlayer());
        return Task.CompletedTask;
    }
}