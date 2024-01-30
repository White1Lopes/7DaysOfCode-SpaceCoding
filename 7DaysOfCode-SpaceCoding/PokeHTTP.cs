using System.Text.Json;
using RestSharp;

namespace _7DaysOfCode_SpaceCoding;

public static class PokeHttp
{
    private const string PokeBaseUrl = "https://pokeapi.co/api/v2/pokemon/";

    public static Mascote GetPokemon(string pokemon)
    {
        var client = new RestClient(PokeBaseUrl + pokemon);

        var request = new RestRequest("", Method.Get);

        var response = client.Execute(request);

        var mascote = JsonSerializer.Deserialize<Mascote>(response.Content);

        return mascote;
    }
}