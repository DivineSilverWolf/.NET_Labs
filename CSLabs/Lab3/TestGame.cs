using Lab1;
using Lab1.card;
using Lab1.Color;
using Lab1.God;
using Moq;
using Lab1.Players;
using Lab1.Strategy;

namespace Lab3;
[TestFixture]
public class TestGame
{
    [Test]
    public void LosePlayTested()
    {
        var elon = new Elon(new StrategyNumberOne());
        var mark = new Mark(new StrategyNumberOne());
        var gameGuidedByTheGod = new GameGuidedByTheGod(2, 36);
        var game = new Game(elon, mark, gameGuidedByTheGod);
        elon.CardDeck = gameGuidedByTheGod.DealTheDeckForPlayer();
        mark.CardDeck = gameGuidedByTheGod.DealTheDeckForPlayer();
        Assert.That(game.PlayResult(), Is.False);
    }
    [Test]
    public void WinPlayTested()
    {
        var elon = new Elon(new StrategyNumberOne());
        var mark = new Mark(new StrategyNumberOne());
        var gameGuidedByTheGod = new GameGuidedByTheGod(2, 36);
        var game = new Game(elon, mark, gameGuidedByTheGod);
        var list1 = gameGuidedByTheGod.DealTheDeckForPlayer();
        var list2 = gameGuidedByTheGod.DealTheDeckForPlayer();

        list1[0] = new Card(Color.Red);
        list2[0] = new Card(Color.Red);
        elon.CardDeck = list1;
        mark.CardDeck = list2;
        Assert.That(game.PlayResult(), Is.True);
    }
    
    [Test]
    public void ShuffleDeckGameTested()
    {
        var elon = new Elon(new StrategyNumberOne());
        var mark = new Mark(new StrategyNumberOne());
        var gameGuidedByTheGod = new GameGuidedByTheGod(2, 36);
        var game = new Game(elon, mark, gameGuidedByTheGod);
        var deck = gameGuidedByTheGod.DealTheDeckForPlayer().Concat(gameGuidedByTheGod.DealTheDeckForPlayer());
        game.DealTheDeckForPlayers();
        var shuffleDeck = gameGuidedByTheGod.DealTheDeckForPlayer().Concat(gameGuidedByTheGod.DealTheDeckForPlayer());
        Assert.That(shuffleDeck.ToArray(), Is.Not.EqualTo(deck.ToArray()));
    }
    [Test]
    public void ShuffleDeckGameTestedMoq()
    {
        var gameGuidedByTheGodMock = new Mock<GameGuidedByTheGod>(2, 36);
        var gameGuidedByTheGod = gameGuidedByTheGodMock.Object;
        
        gameGuidedByTheGodMock.Setup(g => g.ShuffleDeck()).Verifiable();

        var elon = new Elon(new StrategyNumberOne());
        var mark = new Mark(new StrategyNumberOne());
        var game = new Game(elon, mark, gameGuidedByTheGod);
        game.DealTheDeckForPlayers();
        
        gameGuidedByTheGodMock.Verify(g => g.ShuffleDeck(), Times.Once);
    }
}