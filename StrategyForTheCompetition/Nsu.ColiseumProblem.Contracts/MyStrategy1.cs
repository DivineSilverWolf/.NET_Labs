using Nsu.ColiseumProblem.Contracts.Cards;

namespace Nsu.ColiseumProblem.Contracts;

public class MyStrategy1: ICardPickStrategy
{
    public int Pick(Card[] cards)
    {
        var x = 0;
        while (true)
        {
            if (x % 2 == 0)
            {
                if(cards[x].Color == CardColor.Red || x == cards.Length - 1) return x;
            }
            else
            {
                if (cards[x].Color == CardColor.Black|| x == cards.Length - 1)
                    return x;
            }
            x++;
        }
    }
}