using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Model;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        //gelen id li kişi var mı yok mu
        public bool CategoryExist(int id)
        {
            return _context.Categories.Any(c => c.Id == id);    
        }
        //kategorileri getir
        public ICollection<Category> GetCategories() => _context.Categories.ToList();
        //kategorileri id'ye göre getirir
        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }
        //Kategoriye göre pokemonları getir
        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }
        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }
            public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }
    }
}
