using Lab4;

namespace Lab6_Gods.DataBaseControl;

public class DbInfo
{
    public int Index { get; set; }
    public ApplicationContext Db { get; }

    public DbInfo(ApplicationContext db, int index)
    {
        Db = db;
        Index = index;
    }
}
