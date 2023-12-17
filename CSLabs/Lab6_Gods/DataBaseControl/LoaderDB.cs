using Lab4;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lab6_Gods.DataBaseControl;

public static class LoaderDb
{
    public static DbInfo LoadDb(int index)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("DataBaseControl/app-settings.json")
            .Build();
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>(); 
        optionsBuilder.UseSqlite(configuration.GetConnectionString("ApplicationContext"));
        var db = new ApplicationContext(optionsBuilder.Options);
        return new DbInfo(db, index);
    }
}