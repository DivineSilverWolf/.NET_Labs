using Lab1.card;
using Lab1.Strategy.ParentStrategy;

namespace Lab1.Strategy
{
    public class StrategyNumberOne: IStrategy
    {
        public int ReturnNumberCard(List<Card> list)
        {   
            var x = 0;
            while (true)
            {
                if (list[x].Color == Color.Color.Red || x == list.Count - 1) return x;
                x++;
            }
        }
    }
}