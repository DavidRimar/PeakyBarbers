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
    public class BarberDetailsModel : PageModel
    {
        // PROPERTIES
        public BarberDetails BarberDetails { get; set; }
        public IReadOnlyCollection<WorkingHoursHeader> WorkingHours { get; set; }
        public BarbersService BarbersService { get; }

        // CONSTRUCTOR
        public BarberDetailsModel(BarbersService barbersService)
        {
            BarbersService = barbersService;
        }

        // GET METHODS
        public async Task<IActionResult> OnGetAsync(int id)
        {
            // get barber
            BarberDetails = await BarbersService.GetBarberDetailsByIdAsync(id);

            // get working hours
            WorkingHours = await BarbersService.GetWorkingHoursForBarberAsync(id);

            if (BarberDetails == null)
            {
                return NotFound();
            }

            return Page();

        }
    }
}
