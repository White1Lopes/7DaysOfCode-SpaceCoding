﻿namespace _7DaysOfCode_SpaceCoding;

public static class Menu
{
    public static string ShowInitialMessage()
    {
        Console.WriteLine("\n ──────────────");
        Console.WriteLine("Bem-vindo ao jogo de adoção de mascotes!");
        Console.Write("Por favor, digite seu nome: ");
        string nomeJogador = Console.ReadLine();
        Console.WriteLine("Olá, " + nomeJogador + "! Vamos começar!");
        return nomeJogador;
    }

    public static void ShowPrincipalMenu(string name)
    {
        Console.WriteLine("----------------------------MENU---------------------------");
        Console.WriteLine($"{name} você deseja:");
        Console.WriteLine("1 - Adotar um mascote virtual");
        Console.WriteLine("2. Interagir com seu Mascote");
        Console.WriteLine("3. Ver Mascotes Adotados");
        Console.WriteLine("4. Sair do Jogo");
        Console.WriteLine();
    }

    public static void ShowInteractionMenu()
    {
        Console.WriteLine("\n ──────────────");
        Console.WriteLine("Menu de Interação:");
        Console.WriteLine("1. Saber como o mascote está");
        Console.WriteLine("2. Alimentar o mascote");
        Console.WriteLine("3. Brincar com o mascote");
        Console.WriteLine("4. Botar o mascote para dormir");
        Console.WriteLine("5. Fazer carinho no mascote");
        Console.WriteLine("6. Voltar");
        Console.Write("Escolha uma opção: ");
    }

    public static int GetTrainerChoice(int min = 0, int max = 3)
    {
        int choice;

        while (!int.TryParse(Console.ReadLine(), out choice) || choice < min + 1 || choice > max)
        {
            Console.Write($"Escolha inválida. Por favor, escolha uma opção entre {min + 1} e {max}: ");
        }

        return choice;
    }

    public static void ShowAdoptionMenu()
    {
        Console.WriteLine("\n ──────────────");
        Console.WriteLine("Menu de Adoção de Mascotes:");
        Console.WriteLine("1. Ver Espécies Disponíveis");
        Console.WriteLine("2. Ver Detalhes de uma Espécie");
        Console.WriteLine("3. Adotar um Mascote");
        Console.WriteLine("4. Voltar ao Menu Principal");
        Console.Write("Escolha uma opção: ");
    }

    public static void ShowAvailableSpecies(string name, List<PokemonResult> pokemonList)
    {
        Console.WriteLine("-------------------ADOTAR UM MASCOTE-----------------------");
        Console.WriteLine($"{name} escolha uma espécie:");
        for (int i = 0; i < pokemonList.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {pokemonList[i].Name}");
        }
    }

    public static void ShowPokemonInfos(PokemonDetailsResult pokemon)
    {
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine($"Nome pokemon: {pokemon.Name}");
        Console.WriteLine($"Altura: {pokemon.Height}");
        Console.WriteLine($"Peso: {pokemon.Weight}");
        Console.WriteLine("Habilidades:");
        foreach (var ability in pokemon.Abilities)
            Console.WriteLine(ability.Ability.Name);
    }

    public static bool ConfirmAdopt()
    {
        Console.WriteLine("\n ──────────────");
        bool loopCondition = true;
        string answer = "";
        
        while (loopCondition)
        {
            Console.Write("Você gostaria de adotar este mascote? (s/n): ");
            answer = Console.ReadLine();
            Console.WriteLine("Digite s ou n por favor!");
            loopCondition = answer?.ToLower() != "s" && answer?.ToLower() != "sim" && answer?.ToLower() != "n" &&
                            answer?.ToLower() != "não";
        }

        return answer?.ToLower() == "s" || answer?.ToLower() == "sim";
    }

    public static void ShowAdoptedPets(List<PoketochiDTO> adoptedPets)
    {
        Console.WriteLine("\n ──────────────");
        Console.WriteLine("Mascotes Adotados:");
        if (adoptedPets.Count == 0)
        {
            Console.WriteLine("Você ainda não adotou nenhum mascote.");
        }
        else
        {
            for (int i = 0; i < adoptedPets.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + adoptedPets[i].Name);
            }
        }
    }

    public static int GetChosenSpecie(List<PokemonResult> species)
    {
        Console.WriteLine("\n ──────────────");
        int escolha;
        while (true)
        {
            Console.Write("Escolha uma espécie pelo número (1-" + species.Count + "): ");
            if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= species.Count)
            {
                break;
            }

            Console.WriteLine("Escolha inválida.");
        }

        return escolha - 1;
        // Ajuste para índice baseado em 0
    }
}