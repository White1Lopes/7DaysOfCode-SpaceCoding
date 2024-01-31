using System.Text.Json;
using RestSharp;

namespace _7DaysOfCode_SpaceCoding;

public static class PokeHttp
{
    private const string PokeBaseUrl = "https://pokeapi.co/api/v2/pokemon/";

    private static JsonSerializerOptions Options = new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    
    public static List<PokemonResult> GetAllAvailableSpecies()
    {
        // Obter a lista de espécies de Pokémons

        var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
        var request = new RestRequest("", Method.Get);
        var response = client.Execute(request);

        var pokemonEspeciesResposta = JsonSerializer.Deserialize<PokemonSpeciesResult>(response.Content, Options);

        return pokemonEspeciesResposta.Results;
    }
    
    public static PokemonDetailsResult GetPokemon(string pokemon)
    {
        var client = new RestClient(PokeBaseUrl + pokemon);

        var request = new RestRequest("", Method.Get);

        var response = client.Execute(request);

        var mascote = JsonSerializer.Deserialize<PokemonDetailsResult>(response.Content, Options);

        return mascote;
    }
}