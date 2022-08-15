using PokemonReviewApp.Data;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Model;
namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository 
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context)
        {
            _context= context;  
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity= _context.Owners.Where(a=>a.Id==ownerId).FirstOrDefault();
            var category=_context.Categories.Where(a=>a.Id==categoryId).FirstOrDefault();
            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon,
            };

            _context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = pokemon,
            };
            _context.Add(pokemonCategory);
            _context.Add(pokemon);
            return Save();
        }
        public bool DeletePokemon(Pokemon pokemon)
        {
            _context.Remove(pokemon);
            return Save();
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            //DataContext sınıfındaki tanımladığımız Pokemon tablomuzda belirli şartlarla 
            //dizinin ilk öğesini veya öğe bulunamazsa varsayılan değeri döndürür.
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }
        public decimal GetPokemonRating(int pokeId)
        {
            //DataContext sınıfındaki tanımladığımız Reviews tablomuzda girilen id 'ye göre 
            //review değişkenine atanır
            var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);

            //0' a eşitse 0 döndür
            if (review.Count() <= 0)
                return 0;
            //burada da ratingine bak hesapla döndür
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        //Bu metot bütün verileri getirmesini sağlar
        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public object GetPokemonTrimToUpper(PokemonDto pokemonCreate)
        {
            return GetPokemons().Where(c => c.Name.Trim().ToUpper() == pokemonCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool PokemonExist(int pokeId)
        {
            return _context.Pokemon.Any(p => p.Id == pokeId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePokemon(int ownerId,int categoryId,Pokemon pokemon)
        {
            _context.Update(pokemon);
            return Save();
        }
    }
}
