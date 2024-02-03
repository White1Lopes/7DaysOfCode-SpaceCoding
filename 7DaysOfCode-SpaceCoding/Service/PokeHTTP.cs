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
        try
        {
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var pokemonEspeciesResposta =
                    JsonSerializer.Deserialize<PokemonSpeciesResult>(response.Content, Options);

                return pokemonEspeciesResposta.Results;
            }

            Console.WriteLine($"Erro ao obter detalhes do Pokémon: {response.Content}");
            return null;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Erro de solicitação: {e.Message}");
            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro inesperado: {e.Message}");
            return null;
        }
    }

    public static PokemonDetailsResult GetPokemon(string pokemon)
    {
        try
        {
            var client = new RestClient(PokeBaseUrl + pokemon);

            var request = new RestRequest("", Method.Get);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var mascote = JsonSerializer.Deserialize<PokemonDetailsResult>(response.Content, Options);
                return mascote;
            }

            return null;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Erro de solicitação: {e.Message}");
            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro inesperado: {e.Message}");
            return null;
        }
    }
}