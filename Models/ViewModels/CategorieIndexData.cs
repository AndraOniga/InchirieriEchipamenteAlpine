namespace InchirieriEchipamenteAlpine.Models.ViewModels
{
    public class CategorieIndexData
    {
            public IEnumerable<Categorie> Categorii { get; set; }
            public IEnumerable<EchipamentAlpin> EchipamenteAlpine { get; set; }
            public IEnumerable<CategorieEchipament> CategoriiEchipamente { get; set; }
      }
}
