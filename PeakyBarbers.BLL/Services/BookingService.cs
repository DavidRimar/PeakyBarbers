using Microsoft.EntityFrameworkCore;
using PeakyBarbers.BLL.ExpressionMappers;
using PeakyBarbers.Data;
using PeakyBarbers.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeakyBarbers.BLL.Services.DTOs;
using PeakyBarbers.Data.Entities;

namespace PeakyBarbers.BLL.Services
{
    public class BookingService
    {
        // CONSTRUCTOR
        public BookingService(PeakyBarbersDbContext petManagerDbContext)
        {
            DbContext = petManagerDbContext;
        }

        // PROPERTIES
        public PeakyBarbersDbContext DbContext { get; }

        // GET METHODs
        /// <summary>
        /// Gets All Appointments for the specified period.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<AppointmentSlotHeader>> GetAllAppointmentSlotsBetweenDatesAsync(DateTime fromDate, DateTime toDate)
        {

            // get appointment slots for a range of dates
            var appSlots = DbContext.AppointmentSlots.Where(app => app.DayOfYear >= fromDate && app.DayOfYear < toDate);

            return await appSlots.Select(AppointmentSlotSelectors.AppointmentSlotHeaderSelector).OrderBy(a => a.DayOfYear).ThenBy(a => a.StartTime).ToListAsync();
        }

        public async Task<IList<AppointmentSlotHeader>> GetAppointmentSlotsForUser(int userId, UserRoles userRole)
        {
            // get appointment slots for a user Id
            if (userRole == UserRoles.Barber) { 
                var appSlots = DbContext.AppointmentSlots.Where(app => app.BarberId == userId);
                return await appSlots.Select(AppointmentSlotSelectors.AppointmentSlotHeaderSelector).OrderBy(a => a.DayOfYear).ThenBy(a => a.StartTime).ToListAsync();
            }
            else {
                var appSlots = DbContext.AppointmentSlots.Where(app => app.CustomerId == userId);
                return await appSlots.Select(AppointmentSlotSelectors.AppointmentSlotHeaderSelector).OrderBy(a => a.DayOfYear).ThenBy(a => a.StartTime).ToListAsync();
            };

        }



        /// <summary>
        /// Gets All Appointment Slots for the current week.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<AppointmentSlotHeader>> GetAppointmentSlotsForCurrentWeekAsync(string startDate)
        {
            var dtStartDate = DateTime.Parse(startDate);

            return await GetAllAppointmentSlotsBetweenDatesAsync(dtStartDate, dtStartDate.AddDays(7));
        }

        /// <summary>
        ///  Get an Appointment slot by ID. Maps to AppointmentSlotEdit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AppointmentSlotCustomerEdit> GetAppointmentSlotCustomerEditByIdAsync(int id)
        {
            // get appointment slot by ID
            var appSlots = DbContext.AppointmentSlots.Where(app => app.Id == id);

            return await appSlots.Select(AppointmentSlotSelectors.AppointmentSlotCustomerEditSelector).SingleOrDefaultAsync();
        }

        public async Task<AppointmentSlotDelete> GetAppointmentToDeleteByIdAsync(int id)
        {
            return await DbContext.AppointmentSlots.Where(a => a.Id == id)
                                        .Select(AppointmentSlotSelectors.AppointmentSlotDeleteSelector)
                                        .SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets Services.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<ServiceHeader>> GetServicesAsync()
        {
            return await DbContext.Services.Where(s => s.IsDeleted == false).Select(ServiceSelectors.ServiceHeaderSelector).ToListAsync();
        }

        public async Task<IList<BarberFullName>> GetBarberFullNamesAsync()
        {
            return await DbContext.Barbers.Select(BarberSelectors.BarberFullNameSelector).ToListAsync();
        }

        // POST METHODs
        public async Task<int> PostAppointmentSlotCustomerUpdateByIdAsync(AppointmentSlotCustomerEdit asPost)
        {

            // get domain entity by ID
            AppointmentSlot asT = await DbContext.AppointmentSlots.Where(app => app.Id == asPost.Id).SingleAsync();

            // set Customer Id on domain entity from DTO
            asT.CustomerId = asPost.CustomerId;

            // set Service Id on domain entity from DTO
            asT.ServiceId = asPost.ServiceId;

            // set BookingStatus to Booked
            asT.BookingStatus = BookingStatus.Booked;

            // set Modified Date to DateTime Now
            asT.ModifiedDate = DateTime.Now;

            // save changes
            await DbContext.SaveChangesAsync();

            return asT.Id;
        }

        public async Task<int> PostDeleteAppointmentSlot(int id)
        {

            // remove by Id
            DbContext.AppointmentSlots.Remove(new AppointmentSlot { Id = id });
            await DbContext.SaveChangesAsync();

            return id;
        }

        public async Task<bool> PostCreateAppointment(AppointmentSlotCreate appointmentToCreate)
        {
            AppointmentSlot newAppointment = new AppointmentSlot
            {
                BarberId = appointmentToCreate.BarberId,
                DayOfYear = appointmentToCreate.DayOfYear,
                StartTime = appointmentToCreate.StartTime,
                EndTime = appointmentToCreate.EndTime,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                BookingStatus = BookingStatus.Available
            };

            DbContext.Add(newAppointment);

            await DbContext.SaveChangesAsync();

            return true;
        }

    }
}
