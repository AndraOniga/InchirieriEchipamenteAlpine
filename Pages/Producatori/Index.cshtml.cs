using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InchirieriEchipamenteAlpine.Data;
using InchirieriEchipamenteAlpine.Models;
using System.Security.Policy;
using InchirieriEchipamenteAlpine.Models.ViewModels;

namespace InchirieriEchipamenteAlpine.Pages.Producatori
{
    public class IndexModel : PageModel
    {
        private readonly InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext _context;

        public IndexModel(InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext context)
        {
            _context = context;
        }

        public IList<Producator> Producator { get; set; } = default!;

        public ProducatorIndexData ProducatorData { get; set; }
        public int ProducatorID { get; set; }
        public int EchipamentAlpinID { get; set; }
        public async Task OnGetAsync(int? id, int? echipamentAlpinID)
        {
            ProducatorData = new ProducatorIndexData();
            ProducatorData.Producatori = await _context.Producator
            .Include(i => i.EchipamenteAlpine)
            .ThenInclude(c => c.Distribuitor)
            .OrderBy(i => i.NumeProducator)
            .ToListAsync();
            if (id != null)
            {
                ProducatorID = id.Value;
                Producator producator = ProducatorData.Producatori
                .Where(i => i.ID == id.Value).Single();
                ProducatorData.EchipamenteAlpine = producator.EchipamenteAlpine;
            }

        }
    }
}
