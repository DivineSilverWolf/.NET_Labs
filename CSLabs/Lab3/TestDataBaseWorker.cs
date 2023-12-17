using Lab1.card;
using Lab4;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Lab3;

[TestFixture]
public class TestDataBaseWorker
{
    private const string TestPath = "C:\\Users\\Vlad\\RiderProjects\\CSLabs\\Lab3\\dbsettings.json";
    private readonly Card[] _loseDeck = DecksForTest.LoseDeck;
    [Test]
    public void WriteDataBase_ShouldAddExperimentToDatabase()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(TestPath)
            .Build();
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>(); 
        optionsBuilder.UseSqlite(configuration.GetConnectionString("ApplicationContext"));
        var db = new ApplicationContext(optionsBuilder.Options); 
        db.NewGenerationDataBase();
        var deckPlayerOne = _loseDeck.ToList().GetRange(0, 18);
        var deckPlayerTwo = _loseDeck.ToList().GetRange(18, 18);
        DataBaseWorker.WriteDataBase(db, deckPlayerOne, deckPlayerTwo);
        Assert.Multiple(() =>
        {
            Assert.That(db.Experiments.Count(), Is.EqualTo(1));
            Assert.That(db.Experiments.First().DeckForPlayerOne, Is.EqualTo(JsonConvert.SerializeObject(deckPlayerOne)));
            Assert.That(db.Experiments.First().DeckForPlayerTwo, Is.EqualTo(JsonConvert.SerializeObject(deckPlayerTwo)));
        });
    }

    [Test]
    public void ReadDataBase_ShouldReturnDecksFromDatabase()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(TestPath)
            .Build();
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>(); 
        optionsBuilder.UseSqlite(configuration.GetConnectionString("ApplicationContext"));
        var db = new ApplicationContext(optionsBuilder.Options); 
        db.NewGenerationDataBase();
        var deckPlayerOne = _loseDeck.ToList().GetRange(0, 18);
        var deckPlayerTwo = _loseDeck.ToList().GetRange(18, 18);
        DataBaseWorker.WriteDataBase(db, deckPlayerOne, deckPlayerTwo);
        var result = DataBaseWorker.ReadDataBase<Card>(db, 1);
        Assert.Multiple(() =>
        {
            Assert.That(result.Item1.Select(c => c.Color), Is.EqualTo(deckPlayerOne.Select(c => c.Color)));
            Assert.That(result.Item2.Select(c => c.Color), Is.EqualTo(deckPlayerTwo.Select(c => c.Color)));
        });
    }
}