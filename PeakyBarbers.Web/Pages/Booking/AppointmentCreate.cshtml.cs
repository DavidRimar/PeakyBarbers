using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeakyBarbers.BLL.Services;
using PeakyBarbers.BLL.Services.DTOs;

namespace PeakyBarbers.Web.Pages.Services
{
    public class AppointmentCreateModel : PageModel
    {
        // PROPERTIES
        public BookingService BookingService { get; }

        [BindProperty]
        public AppointmentSlotCreate AppointmentToCreate { get; set; }

        // CONSTRUCTOR
        public AppointmentCreateModel(BookingService bookingService)
        {
            BookingService = bookingService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { 
                return Page();
            }

            await BookingService.PostCreateAppointment(AppointmentToCreate);

            return RedirectToPage("./AppointmentList");
        }
    }
}
