using AutoMapper;

namespace _7DaysOfCode_SpaceCoding;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<PokemonDetailsResult, PoketochiDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
            .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
            .ForMember(dest => dest.Abilitys, opt => opt.MapFrom(src => src.Abilities.Select(a => new AbilityDto(){ Nome = a.Ability.Name})));
    }

    public class PetService
    {
        private readonly IMapper _mapper;

        public PetService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PoketochiDTO CreatePet(PokemonDetailsResult pokemon)
        {
            return _mapper.Map<PoketochiDTO>(pokemon);
        }
    }
    
}