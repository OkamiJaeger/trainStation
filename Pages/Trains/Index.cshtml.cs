using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using trainStation.Data;
using trainStation.Model;

namespace trainStation.Pages.Trains
{
    public class IndexModel : PageModel
    {
        private readonly trainStation.Data.trainStationContext _context;

        public IndexModel(trainStation.Data.trainStationContext context)
        {
            _context = context;
        }

        public IList<Train> Train { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Train = await _context.Train.ToListAsync();
        }
    }
}
