using Lab1.card;
using Lab1.Strategy.ParentStrategy;

namespace Lab1.Strategy
{
    public class StrategyNumberThree: IStrategy
    {
        public int ReturnNumberCard(List<Card> list)
        {
            var countRed = 0;
            var countBlack = 0;
            var indexRed = 0;
            var indexBlack = 0;
            for (var i = 0; i<list.Count; i++)
            {
                if (list[i].Color == Color.Color.Red) {
                    countRed++;
                    indexRed = i;
                }
                else {
                    countBlack++;
                    indexBlack = i;
                }
            }

            return countRed < countBlack ? indexRed : indexBlack;
            
        }
    }
}