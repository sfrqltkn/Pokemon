namespace PokemonReviewApp.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Country ve Owner arasında one to many ilişkisi olduğu için
        //ve country uml diyagramında Owners many ilişki olarak tasarlandığı için 
        //Collection listesini yaparak bir değişken tanımladık
        public ICollection<Owner> Owners { get; set; }
    }
}
