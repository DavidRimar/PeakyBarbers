using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        [BindProperty(SupportsGet = true)]
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
            BarberList = new List<SelectListItem>() { };
        }

        // GET METHODS
        public async Task<IActionResult> OnGetAsync(string? date)
        {
            // load data required for the page
            await LoadAsync(date);

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

        // POST METHODS
        public async Task<IActionResult> OnPostCustomerEditAppointmentSlotAsync()
        {

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

                // loadAsync to reload the data
                await LoadAsync(CurrentWeekStartDayString);

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
            return RedirectToPage("../MyAppointments/Index");

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
            // if no date is passed in
            if (date == null && CurrentWeekStartDayString == null)
            {
                // set default start dates
                CurrentWeekStartDayString = DateTime.Today.ToString("dd-MM-yyyy");
                PreviousWeekStartDayString = DateTime.Today.AddDays(-7).ToString("dd-MM-yyyy");
                NextWeekStartDayString = DateTime.Today.AddDays(7).ToString("dd-MM-yyyy");
            }
            // if the user filters, stay on the current week
            else if (CurrentWeekStartDayString != null) {

                CurrentWeekStartDayString = CurrentWeekStartDayString;
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

            for (int i = 0; i < ServiceCollection.Count; i++)
            {
                ServiceList.Add(new SelectListItem { Text = ServiceCollection[i].ServiceName, Value = ServiceCollection[i].Id.ToString() });
            }

        }

        private async Task<bool> SetBarberListItems()
        {
            IList<BarberFullName> barberNames = await BookingService.GetBarberFullNamesAsync();

            // BarberList = new List<SelectListItem>() { };

            for (int i = 0; i < barberNames.Count; i++)
            {

                BarberList.Add(new SelectListItem { Text = barberNames[i].barberFullName, Value = barberNames[i].barberFullName });
            }

            return true;
        }

        private async Task LoadAsync(string? date)
        {

            // assuming that the request for the page comes with a date string
            // call SetStartDates method
            SetStartDates(date);

            // get all appointment slots for this period
            AllAppointmentSlotHeaders = await BookingService.GetAppointmentSlotsForCurrentWeekAsync(CurrentWeekStartDayString);

            // works for the first time

            // filter by barber
            if (!string.IsNullOrEmpty(SelectedBarberFullName))
            {
                // selecteBarberFullName can be "All Barbers"
                AllAppointmentSlotHeaders = AllAppointmentSlotHeaders.Where(f => f.BarberFullName == SelectedBarberFullName).ToList();
            }

            // set BarberList from appointments
            var finished = await SetBarberListItems();

            Debug.WriteLine("Finsihed: ", finished);

        }
    }
}
