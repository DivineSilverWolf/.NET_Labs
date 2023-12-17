using Lab1.card;
using Lab1.Color;
using Lab1.Strategy.ParentStrategy;

namespace lab1.Strategy;

public class StrategyNumberFour: IStrategy
{
    public int ReturnNumberCard(List<Card> list)
    {
        var random = new Random();
        var x = 0;
        var count = list.Count;
        while (--count != 0)
        {
            if (list[x].Color == Color.Red || x == list.Count - 1) return x;
            x = random.Next() % list.Count;
        }
        return x;
    }
    
}