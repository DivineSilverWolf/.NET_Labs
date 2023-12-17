using Lab1.card;
using Lab1.Color;

namespace Lab3;

public static class DecksForTest
{
    public static readonly Card[] LoseDeck =
    {
        new Card(Color.Red), new Card(Color.Red), new Card(Color.Red),
        new Card(Color.Red), new Card(Color.Red), new Card(Color.Red),
        new Card(Color.Red), new Card(Color.Red), new Card(Color.Red),
        new Card(Color.Red), new Card(Color.Red), new Card(Color.Red),
        new Card(Color.Red), new Card(Color.Red), new Card(Color.Red),
        new Card(Color.Red), new Card(Color.Red), new Card(Color.Red),
            
        new Card(Color.Black), new Card(Color.Black), new Card(Color.Black),
        new Card(Color.Black), new Card(Color.Black), new Card(Color.Black),
        new Card(Color.Black), new Card(Color.Black), new Card(Color.Black),
        new Card(Color.Black), new Card(Color.Black), new Card(Color.Black),
        new Card(Color.Black), new Card(Color.Black), new Card(Color.Black),
        new Card(Color.Black), new Card(Color.Black), new Card(Color.Black)
    };
    public static readonly Card[] WinDeck =
    {
        new Card(Color.Red), new Card(Color.Black), new Card(Color.Red),
        new Card(Color.Red), new Card(Color.Red), new Card(Color.Red),
        new Card(Color.Red), new Card(Color.Red), new Card(Color.Red),
        new Card(Color.Red), new Card(Color.Red), new Card(Color.Red),
        new Card(Color.Red), new Card(Color.Red), new Card(Color.Red),
        new Card(Color.Red), new Card(Color.Red), new Card(Color.Red),

        new Card(Color.Red), new Card(Color.Black), new Card(Color.Black),
        new Card(Color.Black), new Card(Color.Black), new Card(Color.Black),
        new Card(Color.Black), new Card(Color.Black), new Card(Color.Black),
        new Card(Color.Black), new Card(Color.Black), new Card(Color.Black),
        new Card(Color.Black), new Card(Color.Black), new Card(Color.Black),
        new Card(Color.Black), new Card(Color.Black), new Card(Color.Black)
    };
}