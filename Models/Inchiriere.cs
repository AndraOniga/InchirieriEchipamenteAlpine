using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace InchirieriEchipamenteAlpine.Models
{
    public class Inchiriere
    {
        public int ID { get; set; }
        public int? MembruID { get; set; }
        public Membru? Membru { get; set; }
        public int? EchipamentAlpinID { get; set; }
        [Display(Name = "Echipament Alpin")]
        public EchipamentAlpin? EchipamentAlpin { get; set; }
        [Display(Name = "Data returnarii")]
        [DataType(DataType.Date)] public DateTime DataReturnarii { get; set; }
    }
}
