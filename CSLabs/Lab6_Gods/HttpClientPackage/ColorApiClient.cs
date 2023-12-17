using Lab1.Color;

namespace Lab6_Gods.HttpClientPackage;

public class ColorApiClient
{
    private readonly HttpClient _httpClient;

    public ColorApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Color> GetColor(int port)
    {
        var response = await _httpClient.GetAsync($"http://localhost:{port}/getcolor");
        response.EnsureSuccessStatusCode();
        var colorString = await response.Content.ReadAsStringAsync();

        return Enum.Parse<Color>(colorString);
    }
}