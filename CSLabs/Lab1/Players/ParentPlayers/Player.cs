using Lab1.card;
using Lab1.Strategy.ParentStrategy;

namespace Lab1.Players.ParentPlayers
{
    public abstract class Player
    {
        public List<Card> CardDeck {
            get;
            set; } = null!;


        protected readonly IStrategy HisStrategy;

        protected Player(IStrategy strategy)
        {
            HisStrategy = strategy; }

        public Color.Color ChooseCard(int n) {
            return CardDeck[n].Color;
        }

        public abstract int SayCard();
    };
}