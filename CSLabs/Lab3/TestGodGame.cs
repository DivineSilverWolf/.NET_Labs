using Lab1.card;
using Lab1.God;
using Lab1.Strategy;

namespace Lab3;

[TestFixture]
public class TestGodGame
{
    private readonly Card[] _loseDeck = DecksForTest.LoseDeck;
    [Test]
    public void CorrectDeckShuffle()
    {
        var game = new GameGuidedByTheGod(2, 36);
        var deck = game.DealTheDeckForPlayer().Concat(game.DealTheDeckForPlayer());
        game.ShuffleDeck();
        var shuffleDeck = game.DealTheDeckForPlayer().Concat(game.DealTheDeckForPlayer());
        Assert.That(shuffleDeck.ToArray(), Is.Not.EqualTo(deck.ToArray()));
    }
    [Test]
    public void TestCorrectnessFirstPartDeckFromGameGuidedByTheGod()
    {
        var game = new GameGuidedByTheGod(2, 36);
        var cardsGod = game.DealTheDeckForPlayer().ToArray();
        var cardsReds = _loseDeck.ToList().GetRange(0, 18).ToArray();
        var flag = !cardsGod.Where((t, i) => t.Color != cardsReds[i].Color).Any();
        Assert.That(flag, Is.True);
    }
    [Test]
    public void TestCorrectnessSecondPartDeckFromDeckSplitter()
    {
        var game = new GameGuidedByTheGod(2, 36);
        game.DealTheDeckForPlayer();
        var cardsGod = game.DealTheDeckForPlayer().ToArray();
        var cardsBlack = _loseDeck.ToList().GetRange(18, 18).ToArray();
        var flag = !cardsGod.Where((t, i) => t.Color != cardsBlack[i].Color).Any();
        Assert.That(flag, Is.True);
    }
        
    [Test]
    public void NoRedCardInDeckTest()
    {
        var strategy = new StrategyNumberOne();
        var list = _loseDeck.ToList().GetRange(18, 18);
        Assert.That(strategy.ReturnNumberCard(list), Is.EqualTo(17));
    }
}