namespace PokemonReviewApp.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //PokemonCategory deki doldurulması zorunlu
        //alanlar için ICollection interfacini kullanarak
        //yeni bir değişken oluşturduk ve bu değişken PokemonCategory türünde olmalı
        public ICollection<PokemonCategory> PokemonCategories { get; set; }
    }
}
