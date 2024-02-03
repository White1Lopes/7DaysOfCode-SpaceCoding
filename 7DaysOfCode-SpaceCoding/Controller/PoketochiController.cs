namespace _7DaysOfCode_SpaceCoding.Controller;

public class PoketochiController
{
    public List<PokemonResult> availableSpecies { get; set; }
    public Trainer Trainer { get; set; }

    public PoketochiController()
    {
        Trainer = new Trainer();
        availableSpecies = PokeHttp.GetAllAvailableSpecies();
    }
    
    public void Jogar()
    {
        Trainer.Name = Menu.ShowInitialMessage();
        while (true)
        {
            Menu.ShowPrincipalMenu(Trainer.Name);
            int trainerChoice = Menu.GetTrainerChoice(max: 3);

            switch (trainerChoice)
            {
                case 1:
                    AdoptionMenu(Trainer);
                    continue;
                case 2:
                    Menu.ShowAdoptedPets(Trainer.Pets);
                    break;
                case 3:
                    Console.WriteLine("Obrigado por jogar! Até a próxima!");
                    return;
            }
        }
    }

    private void AdoptionMenu(Trainer trainer)
    {
        while (true)
        {
            Menu.ShowAdoptionMenu();
            int choice = Menu.GetTrainerChoice(max: 4);
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
        }
    }
}