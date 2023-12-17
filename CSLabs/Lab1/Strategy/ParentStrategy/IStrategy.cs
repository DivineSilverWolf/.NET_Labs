using Lab1.card;

namespace Lab1.Strategy.ParentStrategy
{
    public interface IStrategy
    { 
        int ReturnNumberCard(List<Card> list);
    }
}