namespace PokemonReviewApp.Model
{
    public class PokemonCategory
    {
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        //PokemonCategory ve Pokemon arasında one to many ilişkisi olduğu için
        //ve pokemon uml diyagramında one ilişki olarak tasarlandığı için sınıftan bir değişken tanımladık
        public Pokemon Pokemon { get; set; }
        public Category Category { get; set; }
    }
}
