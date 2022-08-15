using AutoMapper;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Model;

namespace PokemonReviewApp.Dto
{
    public class PokemonDto 
    {
        //Kullanıcıya belirli bilgileri vermemek için kullanılır.
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
