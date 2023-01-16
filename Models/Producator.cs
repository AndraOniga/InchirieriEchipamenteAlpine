using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace InchirieriEchipamenteAlpine.Models
{
    public class Producator
    {
        public int ID { get; set; }
        [Display(Name = "Denumire Producator")]
        public string NumeProducator { get; set; }
        [Display(Name = "Tara de Origine")]
        public string TaraOrigine { get; set; }

        public ICollection<EchipamentAlpin>? EchipamenteAlpine { get; set; }
    }
}
