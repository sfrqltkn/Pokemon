namespace PokemonReviewApp.Model
{
    public class PokemonOwner
    {
        //Bir köpeğin(Pokemon) birden fazla sahibi olamaz ama bir sahibin(kişinin)
        //birden fazla köpeği olabilir bu ilişki için 2 tablodaki bazı verileri her zaman girmemek için 
        //İki tablo arasında ilişki kurduk
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        //PokemonOwner ve Pokemon arasında one to many ilişkisi olduğu için
        //ve pokemon uml diyagramında one ilişki olarak tasarlandığı için sınıftan bir değişken tanımladık
        public Pokemon Pokemon { get; set; }
        public Owner Owner { get; set; }
    }
}
