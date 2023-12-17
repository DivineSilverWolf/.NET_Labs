 using Lab1.card;
 using Lab1.Color;
 using Lab1.God;
 using Lab1.Players;
 using Lab1.Strategy;
namespace Lab3
{
    [TestFixture]
    public class TestDeck
    {

        [Test]
        public void CorrectAllCardsCount()
        {
            var game = new GameGuidedByTheGod(2, 36);
            var listToMark = game.DealTheDeckForPlayer();
            var listToElon = game.DealTheDeckForPlayer();
            Assert.That(listToElon.Count + listToMark.Count, Is.EqualTo(36));
        }

        [TestCase(Color.Black)]
        [TestCase(Color.Red)]
        public void CorrectCardsCount(Color color)
        {
            var game = new GameGuidedByTheGod(2, 36);
            var listToMark = game.DealTheDeckForPlayer();
            var listToElon = game.DealTheDeckForPlayer();
            
            Assert.That(listToElon.FindAll(e => e.Color == color).Count + listToMark.FindAll(e => e.Color == color).Count, Is.EqualTo(18));
        }
        
    }
}