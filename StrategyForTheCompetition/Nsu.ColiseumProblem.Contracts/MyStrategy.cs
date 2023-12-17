using Nsu.ColiseumProblem.Contracts.Cards;

namespace Nsu.ColiseumProblem.Contracts;

public class MyStrategy: ICardPickStrategy
{
    public int Pick(Card[] cards)
    {
        var x = 0;
        while (true)
        {
            if (cards[x].Color == CardColor.Black || x == cards.Length - 1) return x;
            x++;
        }
    }
}