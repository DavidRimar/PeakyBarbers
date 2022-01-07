using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PeakyBarbers.BLL.Services;
using PeakyBarbers.BLL.Services.DTOs;

namespace PeakyBarbers.Web.Pages.Booking
{
    public class AppointmentListModel : PageModel
    {
        // PROPERTIES
        public BookingService BookingService { get; }

        private readonly ILogger<AppointmentListModel> _logger;

        // List of Appointment Slots
        public IList<AppointmentSlotHeader> AllAppointmentSlotHeaders { get; set; }

        // Single Appointment Slot (Edit via modal)
        [BindProperty]
        public AppointmentSlotCustomerEdit ASEdit { get; set; }

        // All Services
        public IList<ServiceHeader> ServiceCollection { get; set; }

        // All Services as SelectItems
        public IList<SelectListItem> ServiceList { get; set; }

        // All Barbers as SelectItems
        public IList<SelectListItem> BarberList { get; set; }

        // Previous, Current and Next Week Start Days to be used as asp-routes for navigation
        public string PreviousWeekStartDayString { get; set; }
        public string CurrentWeekStartDayString { get; set; }
        public string NextWeekStartDayString { get; set; }

        // Current Week String To Display on Page
        public string CurrentWeekString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedBarberFullName { get; set; }


        // CONSTRUCTOR
        public AppointmentListModel(ILogger<AppointmentListModel> logger, BookingService bookingService)
        {
            _logger = logger;
            BookingService = bookingService;
        }

        // GET METHODS
        public async Task<IActionResult> OnGetAsync(string? date)
        {
            // assuming that the request for the page comes with a date string
            // call SetStartDates method
            SetStartDates(date);

            // get all appointment slots for this period
            AllAppointmentSlotHeaders = await BookingService.GetAppointmentSlotsForCurrentWeekAsync(CurrentWeekStartDayString);

            // filter by barber
            if (!string.IsNullOrEmpty(SelectedBarberFullName))
            {
                AllAppointmentSlotHeaders = AllAppointmentSlotHeaders.Where(f => f.BarberFullName == SelectedBarberFullName).ToList();
            }

            // set BarberList from appointments
            SetBarberListItems();

            return Page();

        }

        public async Task<PartialViewResult> OnGetShowBookModalPartialAsync(int id)
        {

            System.Diagnostics.Debug.WriteLine("SHOW BOOK MODAL");

            // GET Apppintment Slot and set ASEdit property
            ASEdit = await BookingService.GetAppointmentSlotCustomerEditByIdAsync(id);

            // set service collection
            ServiceCollection = await BookingService.GetServicesAsync();

            // create selectItemsList from ServiceCollection
            SetServiceListItems();

            return Partial("_BookAppointment", this);

        }

        public async Task<IActionResult> OnPostFilterBarbersAsync()
        {

            AllAppointmentSlotHeaders.Where(f => f.BarberFullName != SelectedBarberFullName);

            return Page();

        }

        // POST METHODS
        public async Task<IActionResult> OnPostCustomerEditAppointmentSlotAsync()
        {

            if (ASEdit.CustomerId == null) {

                // redirect to log in page
                // or better, show a partial view that lets the User know that he needs to login
                // or, the buttons wont be visible for guests! Simple!
                return Page();
            }

            // convert customerId to int

            // Check model state is valid
            if (!ModelState.IsValid)
            {

                // for debugging model state issues
                foreach (var modelStateKey in ModelState.Keys)
                {

                    var value = ModelState[modelStateKey];
                    foreach (var error in value.Errors)
                    {
                        System.Diagnostics.Debug.WriteLine("Error: ", error);
                    }
                }
                // return page so that no POST operation completes!
                return Page();
            }

            // get customer Id from the logged in User
            // ASEdit.CustomerId = User.Identity.Id

            //var user = await UserManager //.GetUserAsync(User);
            //var userId = user?.Id;

            // use booking service to save changes
            _ = await BookingService.PostAppointmentSlotCustomerUpdateByIdAsync(ASEdit);


            // ONCE EDIT IS DONE, GO BACK TO INDEX PAGE
            return RedirectToPage("./AppointmentList");

            // TODO: GO TO MY PROFILE > MY BOOKINGS PAGE

        }

        // DELETE
        public IActionResult OnPost(int id)
        {

            System.Threading.Thread.Sleep(8000);

            // use Booking Service to delete
            BookingService.PostDeleteAppointmentSlot(id);

            // client-side page rerendering with AJAX
            return new JsonResult(new { url = "reload" });


            // ONCE EDIT IS DONE, GO BACK TO INDEX PAGE
            // return RedirectToPage("./BookingList");

        }

        // PRIVATE METHODS
        private void SetCurrentWeekString()
        {
            var fromDate = CurrentWeekStartDayString.Replace("-", "/");
            var tillDate = DateTime.Parse(NextWeekStartDayString).AddDays(-1).ToString("dd/MM/yyyy");
            CurrentWeekString = fromDate + " - " + tillDate;

        }

        private void SetStartDates(string? date)
        {

            // TODO: For the first time page request, no date is passed in (Date is passed in only after Navigation)
            // Default Start Dates to be DateTime Today!
            // Need to align Seed Data to be generated for 2-4 weeks from DateTime now!

            // if no date is passed in
            if (date == null)
            {
                // set default start dates
                CurrentWeekStartDayString = DateTime.Today.ToString("dd-MM-yyyy");
                PreviousWeekStartDayString = DateTime.Today.AddDays(-7).ToString("dd-MM-yyyy");
                NextWeekStartDayString = DateTime.Today.AddDays(7).ToString("dd-MM-yyyy");
            }
            // else if the user navigates
            else
            {
                // set the current week's start date
                CurrentWeekStartDayString = DateTime.Parse(date).ToString("dd-MM-yyyy");
                PreviousWeekStartDayString = DateTime.Parse(date).AddDays(-7).ToString("dd-MM-yyyy");
                NextWeekStartDayString = DateTime.Parse(date).AddDays(7).ToString("dd-MM-yyyy");
            }

            SetCurrentWeekString();

        }

        private void SetServiceListItems()
        {

            ServiceList = new List<SelectListItem>() { };

            // iterate over Services and create Select Items from them
            for (int i = 0; i < ServiceCollection.Count; i++)
            {
                ServiceList.Add(new SelectListItem { Text = ServiceCollection[i].ServiceName, Value = ServiceCollection[i].Id.ToString() });
            }

        }

        private async void SetBarberListItems()
        {
            IList<BarberFullName> barberNames = await BookingService.GetBarberFullNamesAsync();

            BarberList = new List<SelectListItem>() { };

            for (int i = 0; i < barberNames.Count; i++)
            {

                BarberList.Add(new SelectListItem { Text = barberNames[i].barberFullName, Value = barberNames[i].barberFullName });
            }
        }
    }
}
