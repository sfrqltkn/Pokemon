using PokemonReviewApp.Model;
namespace PokemonReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        //kategorileri getir
        ICollection<Category> GetCategories();
        //kategorileri id'ye göre getirir
        Category GetCategory(int id);
        //Kategoriye göre pokemonları getir
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        //İd li kişi var mı yok mu
        bool CategoryExist(int id);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool CategoryExists(int id);
        bool Save();
    }
}
