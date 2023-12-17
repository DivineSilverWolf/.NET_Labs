using Lab1.card;

namespace Contracts;

public record DeckMessage()
{
    public List<Card> Deck { get; init; }
}