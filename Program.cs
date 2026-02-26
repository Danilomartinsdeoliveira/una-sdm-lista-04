using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using var client = new HttpClient();

        var response = await client.GetAsync("https://api.adviceslip.com/advice");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(json);

        string conselho = doc.RootElement
        .GetProperty("slip")
        .GetProperty("advice")
        .GetString();

        Console.WriteLine("Conselho de Hoje:");
        Console.WriteLine(conselho);
        Console.WriteLine("\nLimpando memória... fim da requisição!");
    }
}