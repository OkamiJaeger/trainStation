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
    public class DetailsModel : PageModel
    {
        private readonly trainStation.Data.trainStationContext _context;

        public DetailsModel(trainStation.Data.trainStationContext context)
        {
            _context = context;
        }

        public Train Train { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var train = await _context.Train.FirstOrDefaultAsync(m => m.Id == id);

            if (train is not null)
            {
                Train = train;

                return Page();
            }

            return NotFound();
        }
    }
}
