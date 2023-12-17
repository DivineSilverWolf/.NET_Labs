using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Lab4;
using Microsoft.EntityFrameworkCore;

public class Experiment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? DeckForPlayerOne { get; set; }  
    public string? DeckForPlayerTwo { get; set; }
}

public sealed class ApplicationContext : DbContext
{
    public DbSet<Experiment> Experiments { get; set; } = null!;
    private readonly string _datasource = null!;

    public ApplicationContext(string datasource)
    {
        _datasource = datasource;
        Database.EnsureCreated();
    }
    public ApplicationContext (DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    public void NewGenerationDataBase()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlite(_datasource != null
    //         ? $"Data Source={_datasource}"
    //         : "Data Source=C:\\Users\\Vlad\\TEST.db");
    // }
}

public static class DataBaseWorker
{
    public static void WriteDataBase<T>(ApplicationContext db, List<T> deckPlayerOne, List<T> deckPlayerTwo)
    {
        var experiment = new Experiment
        {
            DeckForPlayerOne = JsonConvert.SerializeObject(deckPlayerOne),
            DeckForPlayerTwo = JsonConvert.SerializeObject(deckPlayerTwo)
        };
        db.Experiments.Add(experiment);
        db.SaveChanges();
    }

    public static (List<T>?, List<T>?) ReadDataBase<T>(ApplicationContext db, int key)
    {
        var firstOrDefault = db.Experiments.FirstOrDefault(e => e.Id == key);
        return (JsonConvert.DeserializeObject<List<T>>(firstOrDefault?.DeckForPlayerOne ?? string.Empty),
            JsonConvert.DeserializeObject<List<T>>(firstOrDefault?.DeckForPlayerTwo ?? string.Empty));
    }
}