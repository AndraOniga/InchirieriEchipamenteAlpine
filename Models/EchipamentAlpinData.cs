namespace InchirieriEchipamenteAlpine.Models
{
    public class EchipamentAlpinData
    {
        public IEnumerable<EchipamentAlpin> EchipamenteAlpine { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieEchipament> CategoriiEchipamente { get; set; }
    }
}
