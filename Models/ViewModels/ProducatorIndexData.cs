using System.Security.Policy;
using InchirieriEchipamenteAlpine.Models;

namespace InchirieriEchipamenteAlpine.Models.ViewModels
{
    public class ProducatorIndexData
    {
        public IEnumerable<Producator> Producatori { get; set; }
        public IEnumerable<EchipamentAlpin> EchipamenteAlpine { get; set; }

    }
}
