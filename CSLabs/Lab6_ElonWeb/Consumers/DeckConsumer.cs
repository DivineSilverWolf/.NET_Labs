using Contracts;
using Lab1.Strategy;
using Lab1.Strategy.ParentStrategy;
using MassTransit;

namespace Lab6_MarkWeb.Consumers;

public class DeckConsumer : IConsumer<DeckMessage>
{
    public Task Consume(ConsumeContext<DeckMessage> context)
    {
        Console.WriteLine("dsdsds");
        var deck = context.Message.Deck;
        IStrategy strategy = new StrategyNumberOne();
        ElonStats.Cards = deck;
        var decision = strategy.ReturnNumberCard(deck);
        context.Publish(new NumberMessage
        {
            Number = decision,
            Signature = "elon"
        });
        return Task.CompletedTask;
    }
}