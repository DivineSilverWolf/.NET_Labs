using Lab1.card;
using Lab1.Players;
using Lab1.Strategy;

namespace Lab3;

[TestFixture]
public class TestStrategy
{
    private readonly Card[] _loseDeck = DecksForTest.LoseDeck;

    private readonly Card[] _winDeck = DecksForTest.WinDeck;
    [Test]
    public void MarkAndElonLoseTest()
    {
        var strategy = new StrategyNumberOne();
        var elon = new Elon(strategy)
        {
            CardDeck = _loseDeck.ToList().GetRange(0, 18)
        };
        var mark = new Mark(strategy)
        {
            CardDeck = _loseDeck.ToList().GetRange(18, 18)
        };
        var win = mark.ChooseCard(strategy.ReturnNumberCard(elon.CardDeck)) == elon.ChooseCard(strategy.ReturnNumberCard(mark.CardDeck));
        Assert.That(win, Is.False);
    }
        
    [Test]
    public void MarkAndElonWinTest()
    {
        var strategy = new StrategyNumberOne();
        var elon = new Elon(strategy)
        {
            CardDeck = _winDeck.ToList().GetRange(0, 18)
        };
        var mark = new Mark(strategy)
        {
            CardDeck = _winDeck.ToList().GetRange(18, 18)
        };
        var win = mark.ChooseCard(strategy.ReturnNumberCard(elon.CardDeck)) == elon.ChooseCard(strategy.ReturnNumberCard(mark.CardDeck));
        Assert.That(win, Is.True);
    }
}