using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace InchirieriEchipamenteAlpine.Models
{
    public class Distribuitor
    {
        public int ID { get; set; }
        [Display(Name = "Denumire Distribuitor")]
        public string NumeDistribuitor { get; set; }
        public ICollection<EchipamentAlpin>? EchipamenteAlpine { get; set; }
    }
}
