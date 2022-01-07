using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeakyBarbers.BLL.Services;
using PeakyBarbers.BLL.Services.DTOs;
using PeakyBarbers.Data.Enums;

namespace PeakyBarbers.Web.Pages.MyAppointments
{
    public class IndexModel : PageModel
    {
        // PROPERTIES
        public BookingService BookingService { get; }

        public IList<AppointmentSlotHeader> AllAppointmentSlotHeaders { get; set; }

        public int userId { get; set; }

        public UserRoles UserRole{ get; set; }

        public bool IsThereExpiredAppSlot { get; set; }

        public bool IsThereAvailableAppSlot { get; set; }

        // CONSTRUCTOR
        public IndexModel(BookingService bookingService)
        {
            BookingService = bookingService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            AllAppointmentSlotHeaders = await BookingService.GetAppointmentSlotsForUser(userId, DetermineUserRole());

            DetermineAppSlotTypes();

            return Page();
        }

        private UserRoles DetermineUserRole()
        {
            if (User.IsInRole(UserRoles.Customer.ToString()))
            {
                return UserRoles.Customer;
            } else  {
                return UserRoles.Barber;
            }
        }

        private void DetermineAppSlotTypes()
        {
            // if there are any expired
            if (AllAppointmentSlotHeaders.Where(a => a.BookingStatus == BookingStatus.Expired).Any())
            {
                IsThereExpiredAppSlot = true;
            }
            else { 
                IsThereExpiredAppSlot = false;
            }

            // if there are any available
            if (AllAppointmentSlotHeaders.Where(a => a.BookingStatus == BookingStatus.Available).Any())
            {
                IsThereAvailableAppSlot = true;
            }
            else
            {
                IsThereAvailableAppSlot = false;
            }
        }

    }
}
