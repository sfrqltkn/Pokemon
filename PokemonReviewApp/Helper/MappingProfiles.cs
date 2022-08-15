using AutoMapper;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Model;

namespace PokemonReviewApp.Helper
{
    public class MappingProfiles:Profile 
    {
        //Pokemon sınıfın bir nesnesinden PokemonDto sınıfın
        //başka bir nesnesine veri eşlemek ve bu verileri aktarmak  için kullanılır
        //Bunun amacı PokemonDto sınıfındaki aynı değişkenlerle eşleşerek
        //verileri filtrelemek ve kullanıcıya belirli bilgileri vermek
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CountryDto, Country>();
            CreateMap<OwnerDto, Owner>();
            CreateMap<PokemonDto, Pokemon>();
            CreateMap<ReviewDto,Review>();  
            CreateMap<ReviewerDto,Reviewer>();  
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Reviewer, ReviewerDto>();
        }
    }
}
