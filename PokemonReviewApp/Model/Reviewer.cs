namespace PokemonReviewApp.Model
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Reviewer tablosunda review ile arasında one to many ilişkisi olduğu için ve bu tabloda reviews
        //many ilişki olarak tasarlandığı için
        //Collection listesini yaparak bir değişken tanımladık
        public ICollection<Review> Reviews { get; set; }
        //ICollection : Review sınıfındaki doldurulması zorunlu özelliklerin aktarılmasını sağlar
    }
}
