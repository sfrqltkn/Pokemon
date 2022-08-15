using PokemonReviewApp.Dto;
using PokemonReviewApp.Model;

namespace PokemonReviewApp.Interfaces
{
    public interface IPokemonRepository
    {
        //Burada öncelikle yapılacak işlemlerimizi tanımlıyoruz. Daha sonra PokemonRepository kısmında 
        //IPokemonRepository kısmından referans alarak bu parametreleri tek tek dolduruyoruz

        ////////////////////////////
        //Bütün pokemonları getir
        ICollection<Pokemon> GetPokemons();
        //Kullanıcı id girerse parametresi id olan metot çalışır
        Pokemon GetPokemon(int id);
        //Kullanıcı name girerse parametresi name olan metot çalışır
        Pokemon GetPokemon(string  name);
        //pokemonun ratinglerini veren metot
        decimal GetPokemonRating(int pokeId);
        //girilen id var mı yok mu 
        bool PokemonExist(int pokeId);
        bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);
        object GetPokemonTrimToUpper(PokemonDto pokemonCreate);
        bool UpdatePokemon(int ownerId,int categoryId,Pokemon pokemon);
        bool DeletePokemon(Pokemon pokemon);
        bool Save();

    }
}
