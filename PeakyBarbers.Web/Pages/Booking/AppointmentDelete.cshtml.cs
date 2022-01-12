using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeakyBarbers.BLL.Services;
using PeakyBarbers.BLL.Services.DTOs;

namespace PeakyBarbers.Web.Pages.Booking
{
    // [Authorize(Roles = "Barber")]
    public class AppointmentDeleteModel : PageModel
    {
        public BookingService BookingService { get; }

        public AppointmentDeleteModel(BookingService bookingService)
        {
            BookingService = bookingService;
        }

        [BindProperty]
        public AppointmentSlotDelete AppSlotToDelete { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {

            AppSlotToDelete = await BookingService.GetAppointmentToDeleteByIdAsync(id);

            if (AppSlotToDelete == null)
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

            _ = await BookingService.PostDeleteAppointmentSlot(id.Value);

            // TODO: To Confirm Delete on Page, and not redirect

            return RedirectToPage("./AppointmentList");
        }
    }
}
