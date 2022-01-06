using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeakyBarbers.BLL.Services;
using PeakyBarbers.BLL.Services.DTOs;

namespace PeakyBarbers.Web.Pages.Barbers
{
    public class BarberEditModel : PageModel
    {
        public BarbersService BarbersService { get; }

        public BarberEditModel(BarbersService barberService)
        {
            BarbersService = barberService;
        }

        [BindProperty]
        public BarberEdit BarberToEdit { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            BarberToEdit = await BarbersService.GetBarberEditByIdAsync(id);

            if (BarberToEdit == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await BarbersService.EditBarber(BarberToEdit);

            return new RedirectToPageResult("./BarberDetails/", new { id = BarberToEdit.Id });
        }
    }
}
