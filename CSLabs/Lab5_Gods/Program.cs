using System.Text;
using Lab1.card;
using Lab1.God;
using Newtonsoft.Json;

namespace Gods
{
    class Program
    {
        private const int ElonPort = 5001;
        private const int MarkPort = 5002;
        private const int Count = 1_000; 
        private static async Task Main(string[] args)
        {
            var deck = new GameGuidedByTheGod(2, 36);
            var win = 0;
            for (var i = 0; i < Count; i++)
            {
                deck.ShuffleDeck();
                var elonCards = deck.DealTheDeckForPlayer();
                var markCards = deck.DealTheDeckForPlayer();
                var elonChoice = await SendDeckAsync(elonCards, ElonPort);
                var markChoice = await SendDeckAsync(markCards, MarkPort);
                win += markCards[elonChoice].Color == elonCards[markChoice].Color ? 1 : 0;
            }
            Console.WriteLine((double) win / Count * 100 + "%");
        }

        private static async Task<int> SendDeckAsync(List<Card> cards, int port)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(cards); 
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using var response = await client.PostAsync($"http://localhost:{port}/game/getchoice", content);

            response.EnsureSuccessStatusCode();

            var responseBody = Convert.ToInt32(await response.Content.ReadAsStringAsync());
            return responseBody;
        }

    }
}