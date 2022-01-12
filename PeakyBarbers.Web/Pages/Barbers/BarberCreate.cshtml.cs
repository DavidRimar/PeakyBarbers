using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeakyBarbers.BLL.Services;
using PeakyBarbers.BLL.Services.DTOs;

namespace PeakyBarbers.Web.Pages.Barbers
{
    public class BarberCreateModel : PageModel
    {
        public BarbersService BarbersService { get; }

        public BarberCreateModel(BarbersService barbersService)
        {
            BarbersService = barbersService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BarberCreate BarberToCreate { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { 
                return Page();
            }

            await BarbersService.PostCreateBarber(BarberToCreate);

            return RedirectToPage("./BarberList");
        }
    }
}
