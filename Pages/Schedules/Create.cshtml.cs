using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using trainStation.Data;
using trainStation.Model;

namespace trainStation.Pages.Schedules
{
    public class CreateModel : PageModel
    {
        private readonly trainStation.Data.trainStationContext _context;

        public CreateModel(trainStation.Data.trainStationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TrainID"] = new SelectList(_context.Train, "Id", "Company");
            return Page();
        }

        [BindProperty]
        public Schedule Schedule { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Schedule.Add(Schedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
