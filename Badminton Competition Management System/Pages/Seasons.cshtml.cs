using InterfaceLayer;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Badminton_Competition_Management_System.Pages
{
    public class SeasonsModel : PageModel
    {
        private readonly SeasonService _seasonLogic;

        public SeasonsModel(SeasonService seasonLogic)
        {
            _seasonLogic = seasonLogic;
        }

        public List<SeasonsDTO> Seasons { get; set; } = new();

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime EndDate { get; set; }

        public async Task OnGetAsync()
        {
            Seasons = await _seasonLogic.GetSeasonsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                ModelState.AddModelError(string.Empty, "Season name is required.");
            }
            else if (StartDate >= EndDate)
            {
                ModelState.AddModelError(string.Empty, "Start date must be before end date.");
            }

            if (!ModelState.IsValid)
            {
                Seasons = await _seasonLogic.GetSeasonsAsync(); // keep list populated
                ViewData["ShowModal"] = true; // re-open modal on failure
                return Page();
            }

            await _seasonLogic.AddSeasonAsync(Name, StartDate, EndDate);
            return RedirectToPage();
        }
    }
}

