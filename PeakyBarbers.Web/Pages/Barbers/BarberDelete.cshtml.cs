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
    public class BarberDeleteModel : PageModel
    {
        public BarbersService BarbersService { get; }

        public BarberDeleteModel(BarbersService service)
        {
            BarbersService = service;
        }

        [BindProperty]
        public BarberDelete BarberToDelete { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {

            BarberToDelete = await BarbersService.GetBarberToDeleteByIdAsync(id);

            if (BarberToDelete == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await BarbersService.PostDeleteBarber(id);

            return RedirectToPage("./BarberList");
        }
    }
}
