namespace _7DaysOfCode_SpaceCoding;

public class PoketochiDTO
{
    public int Food { get; private set; }
    public int Humor { get; private set; }
    public int Energy { get; private set; }
    public int Health { get; private set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public string Name { get; set; }
    public List<AbilityDto> Abilitys { get; set; }


    public PoketochiDTO()
    {
        var rand = new Random();
        Food = rand.Next(11);
        Humor = rand.Next(11);
        Energy = rand.Next(11);
        Health = rand.Next(11);
    }

    // public void UpdatedProperties(PokemonDetailsResult pokemonDetails)
    // {
    //     Name = pokemonDetails.Name;
    //     Height = pokemonDetails.Height;
    //     Weight = pokemonDetails.Weight;
    //     Abilitys = pokemonDetails.Abilities.Select(a => new AbilityDto { Nome = a.Ability.Name }).ToList();
    // }

    public void Feed()
    {
        Food = Math.Min(Food + 2, 10);
        Energy = Math.Max(Energy - 1, 0);

        Console.WriteLine("Mascote Alimentado!");
    }

    public void Play()
    {
        Humor = Math.Min(Humor + 3, 10);
        Energy = Math.Max(Energy - 2, 0);
        Food = Math.Max(Food - 1, 0);

        Console.WriteLine("Mascote Feliz!");
    }

    public void Rest()
    {
        Energy = Math.Min(Energy + 4, 10);
        Humor = Math.Max(Humor - 1, 0);

        Console.WriteLine("Mascote a Mimir!");
    }

    public void Kindness()
    {
        Humor = Math.Min(Humor + 2, 10);
        Health = Math.Min(Health + 1, 10);

        Console.WriteLine("Mascote Amado!");
    }

    public void ShowStatus()
    {
        Console.WriteLine("Status do Mascote:");
        Console.WriteLine($"Alimentação: {Food}");
        Console.WriteLine($"Humor: {Humor}");
        Console.WriteLine($"Energia: {Energy}");
        Console.WriteLine($"Saúde: {Health}");
    }
}

public class AbilityDto
{
    public string Nome { get; set; }
}