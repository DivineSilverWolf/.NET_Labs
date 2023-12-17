using Contracts;
using Lab1.card;
using Lab4;
using Lab6_Gods.DataBaseControl;
using Lab6_Gods.HttpClientPackage;
using MassTransit;

namespace Lab6_Gods;

public static class DataControl
{
    public static readonly Semaphore Semaphore = new Semaphore(0, 1); 
    private static int TotalSuccesses { get; set; }
    public static int TotalExperiments { get; set; }
    private static int Count { get; set; }

    public static async Task Sender(DbInfo db, ISendEndpoint elonEndpoint, ISendEndpoint markEndpoint)
    {
        if (TotalExperiments == Count)
        {
            Finish();
            return;
        }

        var (elonCards, markCards) = DataBaseWorker.ReadDataBase<Card>(db.Db, db.Index);
        db.Index += 1;
        if (elonCards != null && markCards != null)
        {
            await Task.WhenAll(elonEndpoint.Send(new DeckMessage { Deck = elonCards }),
            markEndpoint.Send(new DeckMessage { Deck = markCards }));
        }
        else
        {
            TotalExperiments = Count;
            Finish();
            Semaphore.Release();
        }
    }

    public static async Task Getter(ColorApiClient colorApiClient, int elonPort, int markPort)
    {
        if (TotalExperiments == Count)
        {
            Finish();
            return;
        }
        var res = await Task.WhenAll(
            colorApiClient.GetColor(elonPort), 
            colorApiClient.GetColor(markPort)
        );

        var (elonColor, markColor) = (res[0], res[1]);
        if (elonColor == markColor)
        {
            TotalSuccesses+=1;
        }
        Count += 1;
    }

    private static void Finish()
    {
        Semaphore.Release();
        var successRate = (double)TotalSuccesses / TotalExperiments * 100;
        Console.WriteLine($"Процент успешных боёв: {successRate}%");
    }
}