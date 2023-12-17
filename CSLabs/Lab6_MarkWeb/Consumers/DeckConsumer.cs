using Contracts;
using Lab1.Strategy;
using Lab1.Strategy.ParentStrategy;
using MassTransit;

namespace Lab6_MarkWeb.Consumers;

public class DeckConsumer : IConsumer<DeckMessage>
{
    public Task Consume(ConsumeContext<DeckMessage> context)
    {
        var deck = context.Message.Deck;
        IStrategy strategy = new StrategyNumberOne();
        MarkStats.Cards = deck;
        var decision = strategy.ReturnNumberCard(deck);
        context.Publish(new NumberMessage
        {
            Number = decision,
            Signature = "zuck"
        });
        return Task.CompletedTask;
    }
}