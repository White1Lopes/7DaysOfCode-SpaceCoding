using _7DaysOfCode_SpaceCoding;
using RestSharp;
using System.Text.Json;

var pokeBaseUrl = "https://pokeapi.co/api/v2/pokemon/";

var ratattaEndpoint = "rattata";

var client = new RestClient(pokeBaseUrl + ratattaEndpoint);

var request = new RestRequest("", Method.Get);

var response = client.Execute(request);

var mascote = JsonSerializer.Deserialize<Mascote>(response.Content);

//dsaoidasd

Console.WriteLine(mascote.name);
Console.WriteLine(mascote.height);
Console.WriteLine(mascote.weight);
foreach (var item in mascote.abilities)
    Console.WriteLine(item.ability.name);
