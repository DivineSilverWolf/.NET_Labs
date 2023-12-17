using Lab1.card;
using Lab1.Strategy.ParentStrategy;

namespace Lab1.Strategy
{
    public class StrategyNumberFive: IStrategy
    {
        public int ReturnNumberCard(List<Card> list)
        {   
            var x = list.Count - 1;
            while (true)
            {
                if (list[x].Color == Color.Color.Red || x == 0) return x;
                x--;
            }
        }
    }
}