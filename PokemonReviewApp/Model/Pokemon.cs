namespace PokemonReviewApp.Model
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Review> Reviews { get; set; }
        //ICollection : Revie sınıfındaki doldurulması zorunlu özelliklerin aktarılmasını sağlar
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
        //ICollection : PokemonOwner sınıfındaki doldurulması zorunlu özelliklerin aktarılmasını sağlar
        public ICollection<PokemonCategory> PokemonCategories { get; set; }
        //ICollection : PokemonCategory sınıfındaki doldurulması zorunlu özelliklerin aktarılmasını sağlar
    }
}
