using Lab1.card;

namespace Lab1.God
{
    public class GameGuidedByTheGod {
        private readonly int _deckSize;
        private readonly int _playersSize;
        private int _issueNumber;
        private List<Card> _cardDeck;
        
        public virtual void ShuffleDeck()
        {
            var random = new Random();
            _cardDeck = _cardDeck.OrderBy (_ => random.Next()).ToList();
        }

        public GameGuidedByTheGod(int playersSize, int deckSize) {
            if (deckSize < playersSize)
                deckSize = playersSize;
            deckSize += deckSize % playersSize;
            
            _playersSize = playersSize;
            _deckSize = deckSize;
            _cardDeck = new List<Card>(_deckSize);
            
            for (var i = 0; i < _deckSize; i++) {
                _cardDeck.Add(new Card(i < _deckSize / 2 ? Color.Color.Red : Color.Color.Black));
            } 
        }

        public List<Card> DealTheDeckForPlayer()
        {
            var index = _issueNumber * _deckSize / _playersSize == 0 ? 0 : _issueNumber * _deckSize / _playersSize;
            var count = _deckSize / _playersSize;
            ++_issueNumber;
            _issueNumber %= _playersSize;
            
            return _cardDeck.GetRange(index, count);
        }
    };
}