using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace InchirieriEchipamenteAlpine.Models
{
    public class EchipamentAlpin
    {
        public int ID { get; set; }
        [Display(Name = "Denumire Produs")]

        public string Denumire { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Pret { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data achizitionarii")]

        public DateTime DataIntrareStoc { get; set; }

        [Display(Name = "Stare produs")]

        public string Stare { get; set; }

        public int? DistribuitorID { get; set; }
        public Distribuitor? Distribuitor { get; set; }
        public int? ProducatorID { get; set; }
        public Producator? Producator { get; set; }

        public ICollection<CategorieEchipament>? CategoriiEchipamente { get; set; }


    }
}
