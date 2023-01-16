using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace InchirieriEchipamenteAlpine.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        [Display(Name = "Denumire Categorie")]
        public string NumeCategorie { get; set; }
        [Display(Name = "Categorie Echipament")]
        public ICollection<CategorieEchipament>? CategoriiEchipamente { get; set; }

    }


}
