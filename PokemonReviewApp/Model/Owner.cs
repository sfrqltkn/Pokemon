namespace PokemonReviewApp.Model
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gym { get; set; }
        //Owner ve Country arasında one to many ilişkisi olduğu için
        //ve country uml diyagramında one ilişki olarak tasarlandığı için sınıftan bir değişken tanımladık
        public Country Country { get; set; }
        //PokemonOwner ve owner arasında one to many ilişkisi olduğu için
        //ve PokemonOwner uml diyagramında many ilişki olarak tasarlandığı için
        //Collection listesini yaparak bir değişken tanımladık
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
    }
}
