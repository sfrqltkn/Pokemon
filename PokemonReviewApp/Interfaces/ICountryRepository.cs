using PokemonReviewApp.Model;
namespace PokemonReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        //Bütün countryleri getir
        ICollection<Country> GetCountries();
        //countryleri id'ye göre getir
        Country GetCountry(int id);
        //owner'A göre countryleri getir
        Country GetCountryByOwner(int ownerId);
        //var mı yok mu kontrol et
        bool CountryExist(int id);
        bool CreateCountry(Country country);
        bool UpdateCountry(Country country);    
        bool DeleteCountry(Country country);
        bool Save();
    }
}
