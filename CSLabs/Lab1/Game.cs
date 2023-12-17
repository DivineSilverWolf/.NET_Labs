using Lab1.God;
using Lab1.Players;
using Lab4;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lab1;

public class Game
{
    protected readonly Elon Elon;
    protected readonly Mark Mark;
    private readonly GameGuidedByTheGod _gameGuidedByTheGod;
    protected readonly ApplicationContext DataBase = null!;
    public Game(Elon elon, Mark mark, GameGuidedByTheGod gameGuidedByTheGod)
    {
        Elon = elon;
        Mark = mark;
        _gameGuidedByTheGod = gameGuidedByTheGod;
    }
    
    public Game(Elon elon, Mark mark, GameGuidedByTheGod gameGuidedByTheGod, IConfigurationRoot configuration)
    {
        Elon = elon;
        Mark = mark;
        _gameGuidedByTheGod = gameGuidedByTheGod;
        
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>(); 
        optionsBuilder.UseSqlite(configuration.GetConnectionString("ApplicationContext"));
        var db = new ApplicationContext(optionsBuilder.Options);
        DataBase = db;
    }
    
    public virtual void DealTheDeckForPlayers()
    {
        _gameGuidedByTheGod.ShuffleDeck();
        Elon.CardDeck = _gameGuidedByTheGod.DealTheDeckForPlayer();
        Mark.CardDeck = _gameGuidedByTheGod.DealTheDeckForPlayer();
        WriteInDataBase();
    }

    public void WriteInDataBase()
    { 
        if(DataBase != null)
            DataBaseWorker.WriteDataBase(DataBase, _gameGuidedByTheGod.DealTheDeckForPlayer(), 
                _gameGuidedByTheGod.DealTheDeckForPlayer());
    }
    
    public bool PlayResult()
    {
        return Elon.ChooseCard(Mark.SayCard()) == Mark.ChooseCard(Elon.SayCard());
    }
}