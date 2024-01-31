using _7DaysOfCode_SpaceCoding;

List<PokemonResult> availableSpecies = PokeHttp.GetAllAvailableSpecies();
Trainer trainer = new();

trainer.Name = Menu.ShowInitialMessage();

while (true)
{
    Menu.ShowPrincipalMenu(trainer.Name);
    int choice = Menu.GetTrainerChoice();

    switch (choice)
    {
        case 1:
            while (true)
            {
                Menu.ShowAdoptionMenu();
                choice = Menu.GetTrainerChoice(max: 4);
                switch (choice)
                {
                    case 1:
                        Menu.ShowAvailableSpecies(trainer.Name, availableSpecies);
                        break;
                    case 2:
                        Menu.ShowAvailableSpecies(trainer.Name, availableSpecies);
                        var specieIndex = Menu.GetChosenSpecie(availableSpecies);
                        var details = PokeHttp.GetPokemon(availableSpecies[specieIndex].Name);
                        Menu.ShowPokemonInfos(details);
                        break;
                    case 3:
                        Menu.ShowAvailableSpecies(trainer.Name, availableSpecies);
                        specieIndex = Menu.GetChosenSpecie(availableSpecies);
                        details = PokeHttp.GetPokemon(availableSpecies[specieIndex].Name);
                        Menu.ShowPokemonInfos(details);
                        if (Menu.ConfirmAdopt())
                        {
                            trainer.Pets.Add(details);
                            Console.WriteLine("Parabéns! Você adotou um " + details.Name + "!");
                            Console.WriteLine("──────────────");
                            Console.WriteLine("────▄████▄────");
                            Console.WriteLine("──▄████████▄──");
                            Console.WriteLine("──██████████──");
                            Console.WriteLine("──▀████████▀──");
                            Console.WriteLine("─────▀██▀─────");
                            Console.WriteLine("──────────────");
                        }

                        break;
                    case 4:
                        break;
                }

                if (choice == 4)
                {
                    break;
                }
            }

            break;

        case 2:
            Menu.ShowAdoptedPets(trainer.Pets);
            break;
        case 3:
            Console.WriteLine("Obrigado por jogar! Até a próxima!");
            return;
    }
}