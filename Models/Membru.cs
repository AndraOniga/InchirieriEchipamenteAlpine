using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace InchirieriEchipamenteAlpine.Models
{
    public class Membru
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau AnaMaria")]

        [StringLength(30, MinimumLength = 3)]
        public string? Nume { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string? Prenume { get; set; }
       
        [StringLength(100)]
        public string? Adresa { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^[0]\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa inceapa cu 0 si fie de forma '0722-123-123' sau'0722.123.123' sau '0722 123 123'")]
        public string? Telefon { get; set; }
        [Display(Name = "Nume si Prenume")] 
        public string? FullName { get { return Nume + " " + Prenume; } }
        public ICollection<Inchiriere>? Inchirieri { get; set; }
    }
}
