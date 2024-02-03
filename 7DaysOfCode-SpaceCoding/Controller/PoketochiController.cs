using AutoMapper;

namespace _7DaysOfCode_SpaceCoding.Controller;

public class PoketochiController
{
    public List<PokemonResult> availableSpecies { get; set; }
    public Trainer Trainer { get; set; }
    private IMapper mapper { get; set; }

    public PoketochiController()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapperProfile>();
        });

        mapper = config.CreateMapper();
        
        Trainer = new Trainer();
        availableSpecies = PokeHttp.GetAllAvailableSpecies();
    }

    public void Jogar()
    {
        Trainer.Name = Menu.ShowInitialMessage();
        while (true)
        {
            Menu.ShowPrincipalMenu(Trainer.Name);
            int trainerChoice = Menu.GetTrainerChoice(max: 4);

            switch (trainerChoice)
            {
                case 1:
                    AdoptionMenu(Trainer);
                    continue;
                case 2:
                    PlayWithAdoptedPet(Trainer);
                    break;
                case 3:
                    Menu.ShowAdoptedPets(Trainer.Pets);
                    break;
                case 4:
                    Console.WriteLine("Obrigado por jogar! Até a próxima!");
                    return;
            }
        }
    }

    private void PlayWithAdoptedPet(Trainer trainer)
    {
        if (trainer.Pets.Count == 0)
        {
            Console.WriteLine("Você não tem mascotes adotados!");
            return;
        }

        Console.WriteLine("Escolha um mascote para interagir:");
        for (int i = 0; i < trainer.Pets.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {trainer.Pets[i].Name}");
        }

        int petIndex = Menu.GetTrainerChoice(max: trainer.Pets.Count) - 1;
        PoketochiDTO poketochiChosen = trainer.Pets[petIndex];

        int trainerChoice = 0;
        while (trainerChoice != 6)
        {
            Menu.ShowInteractionMenu();
            trainerChoice = Menu.GetTrainerChoice(max: 6);

            switch (trainerChoice)
            {
                case 1:
                    poketochiChosen.ShowStatus();
                    break;
                case 2:
                    poketochiChosen.Feed();
                    break;
                case 3:
                    poketochiChosen.Play();
                    break;
                case 4:
                    poketochiChosen.Rest();
                    break;
                case 5:
                    poketochiChosen.Kindness();
                    break;
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
                    if(details is null) break;
                    Menu.ShowPokemonInfos(details);
                    break;
                case 3:
                    Menu.ShowAvailableSpecies(trainer.Name, availableSpecies);
                    specieIndex = Menu.GetChosenSpecie(availableSpecies);
                    details = PokeHttp.GetPokemon(availableSpecies[specieIndex].Name);
                    if(details is null) break;
                    Menu.ShowPokemonInfos(details);
                    if (Menu.ConfirmAdopt())
                    {
                        var poketochi = mapper.Map<PoketochiDTO>(details);
                        trainer.Pets.Add(poketochi);
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
                return;
            }
        }
    }
}