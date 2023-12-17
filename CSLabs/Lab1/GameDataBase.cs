using Lab1.card;
using Lab1.Players;
using Lab4;
using Microsoft.Extensions.Configuration;

namespace Lab1;

public class GameDataBase: Game
{
    private int _index;
    public GameDataBase(Elon elon, Mark mark, IConfigurationRoot configuration, int startIndex) : base(elon, mark, null!, configuration)
    {
        _index = startIndex;
    }
    public override void DealTheDeckForPlayers()
    {
        (Elon.CardDeck, Mark.CardDeck) = DataBaseWorker.ReadDataBase<Card>(DataBase, _index++);
        if (Elon.CardDeck == null || Mark.CardDeck == null)
            throw new InvalidOperationException();
    }
}