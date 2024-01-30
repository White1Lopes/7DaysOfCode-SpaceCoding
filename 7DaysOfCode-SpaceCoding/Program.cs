using _7DaysOfCode_SpaceCoding;

List<string> availablePokemons = ["zubat", "golbat", "crobat"];
int trainerChoiceConverted = 0;
int adoptionChoice = 0;
int pokemonMenuChoice = 0;
Console.WriteLine("Bem vindo ao Poketochi\n");

Console.WriteLine("Qual é o seu nome?\n");
var trainer = new Trainer();
trainer.Name = Console.ReadLine();

do
{
    try
    {
        ShowPrincipalMenu(trainer.Name);

        var trainerChoice = Console.ReadLine();
        trainerChoiceConverted = TryConvertTrainerChoice(trainerChoice);

        if (trainerChoiceConverted == 1)
        {
            adoptionChoice = ShowAdpotionMenuAndChoice(trainer, trainerChoice, adoptionChoice, availablePokemons);
            pokemonMenuChoice = ShowPokemonMenuAndChoice(trainer, trainerChoice, pokemonMenuChoice, availablePokemons, adoptionChoice);
            do
            {
                if (pokemonMenuChoice == 1)
                {
                    ShowPokemonInfos(availablePokemons[adoptionChoice]);
                    pokemonMenuChoice = ShowPokemonMenuAndChoice(trainer, trainerChoice, pokemonMenuChoice, availablePokemons, adoptionChoice);
                }

                if (pokemonMenuChoice == 2)
                {
                    Console.WriteLine(
                        $"{trainer.Name} o {availablePokemons[adoptionChoice]} foi adotado como seu pokemon com sucesso!");
                    trainer.Pets.Add(availablePokemons[adoptionChoice]);
                    break;
                }

                if (pokemonMenuChoice == 3)
                {
                    adoptionChoice = ShowAdpotionMenuAndChoice(trainer, trainerChoice, adoptionChoice, availablePokemons);
                    pokemonMenuChoice = ShowPokemonMenuAndChoice(trainer, trainerChoice, pokemonMenuChoice, availablePokemons, adoptionChoice);
                }
            } while (pokemonMenuChoice != 3);
        }
    }
    catch (Exception e)
    {
        trainerChoiceConverted = 0;
    }
} while (trainerChoiceConverted != 3);

static int ShowAdpotionMenuAndChoice(Trainer trainer, string trainerChoice, int adoptionChoice,
    List<string> availablePokemons)
{
    ShowAdoptionMenu(trainer.Name, availablePokemons);

    trainerChoice = Console.ReadLine();
    adoptionChoice = TryConvertTrainerChoice(trainerChoice, 0, availablePokemons.Count);
    return adoptionChoice - 1;
}

static int ShowPokemonMenuAndChoice(Trainer trainer, string trainerChoice, int pokemonMenuChoice,
    List<string> availablePokemons, int adoptionChoice)
{
    ShowPokemonMenu(trainer.Name, availablePokemons[adoptionChoice]);

    trainerChoice = Console.ReadLine();

    pokemonMenuChoice = TryConvertTrainerChoice(trainerChoice, 0, availablePokemons.Count);
    return pokemonMenuChoice;
}

static void ShowPokemonInfos(string pokemonName)
{
    var pokemon = PokeHttp.GetPokemon(pokemonName);

    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine($"Nome pokemon: {pokemon.name}");
    Console.WriteLine($"Altura: {pokemon.height}");
    Console.WriteLine($"Peso: {pokemon.weight}");
    Console.WriteLine("Habilidades:");
    foreach (var ability in pokemon.abilities)
        Console.WriteLine(ability.ability.name);

    Console.WriteLine();
}

static void ShowPokemonMenu(string name, string pokemonName)
{
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine($"{name} você deseja:");
    Console.WriteLine($"1 - Saber mais sobre {pokemonName}");
    Console.WriteLine($"2 - Adotar {pokemonName}");
    Console.WriteLine("3 - Voltar");
    Console.WriteLine();
}

static void ShowAdoptionMenu(string name, List<string> pokemonList)
{
    Console.WriteLine("-------------------ADOTAR UM MASCOTE-----------------------");
    Console.WriteLine($"{name} escolha uma espécie:");
    for (var i = 0; i < pokemonList.Count; i++)
    {
        Console.WriteLine($"{i + 1} - {pokemonList[i]}");
    }
}

static int TryConvertTrainerChoice(string choice, int min = 0, int max = 3)
{
    int choiceConverted = min;
    try
    {
        choiceConverted = Convert.ToInt16(choice);

        if (choiceConverted <= min || choiceConverted > max)
        {
            throw new Exception();
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Por favor digite um número válido");
        throw;
    }

    return choiceConverted;
}

static void ShowPrincipalMenu(string name)
{
    Console.WriteLine("----------------------------MENU---------------------------");
    Console.WriteLine($"{name} você deseja:");
    Console.WriteLine("1 - Adotar um mascote virtual");
    Console.WriteLine("2 - Ver seus mascotes");
    Console.WriteLine("3 - Sair");
    Console.WriteLine();
}