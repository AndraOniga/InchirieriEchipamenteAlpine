namespace InchirieriEchipamenteAlpine.Models
{
    public class CategorieEchipament
    {
        public int ID { get; set; }
        public int EchipamentAlpinID { get; set; }
        public EchipamentAlpin EchipamentAlpin { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
