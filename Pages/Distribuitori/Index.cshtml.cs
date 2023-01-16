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

namespace InchirieriEchipamenteAlpine.Pages.Distribuitori
{
    public class IndexModel : PageModel
    {
        private readonly InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext _context;

        public IndexModel(InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext context)
        {
            _context = context;
        }

        public IList<Distribuitor> Distribuitor { get;set; } = default!;

        public DistribuitorIndexData DistribuitorData { get; set; }
        public int DistribuitorID { get; set; }
        public int EchipamentApinID { get; set; }
        public async Task OnGetAsync(int? id, int? echipamentID)
        {
            DistribuitorData = new DistribuitorIndexData(); DistribuitorData.Distribuitori = await _context.Distribuitor.Include(i => i.EchipamenteAlpine).ThenInclude(c => c.Producator).OrderBy(i => i.NumeDistribuitor).ToListAsync();
            if (id != null) { DistribuitorID = id.Value; Distribuitor distribuitor = DistribuitorData.Distribuitori.Where(i => i.ID == id.Value).Single(); DistribuitorData.EchipamenteAlpine = distribuitor.EchipamenteAlpine; }
        }
    }
}
