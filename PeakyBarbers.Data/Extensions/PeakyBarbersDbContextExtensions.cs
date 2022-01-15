using PeakyBarbers.Data;
using PeakyBarbers.Data.Entities;
using PeakyBarbers.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeakyBarbers.Data.Extensions
{
    public static class PeakyBarbersDbContextExtensions
    {
        public static async Task EnsureSeedDataForContextAsync(this PeakyBarbersDbContext context, IList<ApplicationUser> barberUserList, IList<ApplicationUser> customerUserList)
        {
            
            int barberUserIdOne = barberUserList[0].Id;
            int barberUserIdTwo = barberUserList[1].Id;
            int barberUserIdThree = barberUserList[2].Id;
            int customerUserIdOne = customerUserList[0].Id;
            int customerUserIdTwo = customerUserList[1].Id;

            // APPOINTMENT SLOTS
            if (!context.AppointmentSlots.Any())
            {
                // Barber 1
                IList<AppointmentSlot> appSlotsList1 = SeedAppointmentSlotsForADay(barberUserIdOne, DateTime.Today.AddDays(-8), 8, null);
                IList<AppointmentSlot> appSlotsList2 = SeedAppointmentSlotsForADay(barberUserIdOne, DateTime.Today.AddDays(-1), 3, null);
                IList<AppointmentSlot> appSlotsList3 = SeedAppointmentSlotsForADay(barberUserIdOne, DateTime.Today, 6, null);
                IList<AppointmentSlot> appSlotsList4 = SeedAppointmentSlotsForADay(barberUserIdOne, DateTime.Today.AddDays(1), 2, null);
                IList<AppointmentSlot> appSlotsList5 = SeedAppointmentSlotsForADay(barberUserIdOne, DateTime.Today.AddDays(7), 7, null);
                IList<AppointmentSlot> appSlotsList6 = SeedAppointmentSlotsForADay(barberUserIdOne, DateTime.Today.AddDays(12), 3, null);

                // Barber 2
                IList<AppointmentSlot> appSlotsList7 = SeedAppointmentSlotsForADay(barberUserIdTwo, DateTime.Today, 5, null);
                IList<AppointmentSlot> appSlotsList8 = SeedAppointmentSlotsForADay(barberUserIdTwo, DateTime.Today.AddDays(2), 6, null);
                IList<AppointmentSlot> appSlotsList9 = SeedAppointmentSlotsForADay(barberUserIdTwo, DateTime.Today.AddDays(10), 6, null);

                // Barber 3
                IList<AppointmentSlot> appSlotsList10 = SeedAppointmentSlotsForADay(barberUserIdThree, DateTime.Today, 4, null);
                IList<AppointmentSlot> appSlotsList11 = SeedAppointmentSlotsForADay(barberUserIdThree, DateTime.Today.AddDays(2), 2, null);
                IList<AppointmentSlot> appSlotsList12 = SeedAppointmentSlotsForADay(barberUserIdThree, DateTime.Today.AddDays(15), 9, null);
                IList<AppointmentSlot> appSlotsList13 = SeedAppointmentSlotsForADay(barberUserIdThree, DateTime.Today.AddDays(-6), 1, customerUserIdOne); // booked in the past
                IList<AppointmentSlot> appSlotsList14 = SeedAppointmentSlotsForADay(barberUserIdThree, DateTime.Today.AddDays(-5), 1, customerUserIdTwo); // booked in the past
                IList<AppointmentSlot> appSlotsList15 = SeedAppointmentSlotsForADay(barberUserIdThree, DateTime.Today.AddDays(6), 1, customerUserIdOne); // booked in the future

                context.AppointmentSlots.AddRange(appSlotsList1);
                context.AppointmentSlots.AddRange(appSlotsList2);
                context.AppointmentSlots.AddRange(appSlotsList3);
                context.AppointmentSlots.AddRange(appSlotsList4);
                context.AppointmentSlots.AddRange(appSlotsList5);
                context.AppointmentSlots.AddRange(appSlotsList6);
                context.AppointmentSlots.AddRange(appSlotsList7);
                context.AppointmentSlots.AddRange(appSlotsList8);
                context.AppointmentSlots.AddRange(appSlotsList9);
                context.AppointmentSlots.AddRange(appSlotsList10);
                context.AppointmentSlots.AddRange(appSlotsList11);
                context.AppointmentSlots.AddRange(appSlotsList12);
                context.AppointmentSlots.AddRange(appSlotsList13);
                context.AppointmentSlots.AddRange(appSlotsList14);
                context.AppointmentSlots.AddRange(appSlotsList15);

                await context.SaveChangesAsync();
            }

            // WORKING HOURS
            if (!context.WorkingHours.Any())
            {
                // Barber 1
                IList<WorkingHour> workingHours1 = SeedWorkingHours(barberUserIdOne);

                // Barber 2
                IList<WorkingHour> workingHours2 = SeedWorkingHours(barberUserIdTwo);

                context.WorkingHours.AddRange(workingHours1);
                context.WorkingHours.AddRange(workingHours2);

                await context.SaveChangesAsync();
            }

        }

        private static IList<AppointmentSlot> SeedAppointmentSlotsForADay(int barberId, DateTime date, int numberOfAppointments, int? customerId)
        {

            IList<AppointmentSlot> entities = new List<AppointmentSlot>();

            TimeSpan startTime = new TimeSpan(8, 0, 0);
            TimeSpan endTime = new TimeSpan(9, 0, 0);

            for (int i = 0; i < numberOfAppointments; i++) {

                // if day is before today, booking status is expired
                var bookingStatus = (DateTime.Compare(date, DateTime.Today) < 0) ? BookingStatus.Expired: BookingStatus.Available;

                if (customerId != null && bookingStatus != BookingStatus.Expired) {
                    bookingStatus = BookingStatus.Booked;
                }

                AppointmentSlot appSlot = new AppointmentSlot { BarberId = barberId, CustomerId = customerId, DayOfYear = date, StartTime = startTime, EndTime = endTime, BookingStatus = bookingStatus, CreationDate = DateTime.Now, ModifiedDate = DateTime.Now };

                entities.Add(appSlot);

                startTime += TimeSpan.FromHours(1);
                endTime += TimeSpan.FromHours(1);

            }

            return entities;
        }

        private static IList<WorkingHour> SeedWorkingHours(int barberId)
        {

            IList<WorkingHour> entities = new List<WorkingHour>();

            WorkingHour monday = new WorkingHour { BarberId = barberId, Day = DayOfWeek.Monday, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(16, 30, 0), CreationDate = DateTime.Now, ModifiedDate = DateTime.Now };
            WorkingHour tuesday = new WorkingHour { BarberId = barberId, Day = DayOfWeek.Tuesday, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(16, 30, 0), CreationDate = DateTime.Now, ModifiedDate = DateTime.Now };
            WorkingHour wednesday = new WorkingHour { BarberId = barberId, Day = DayOfWeek.Wednesday, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(16, 30, 0), CreationDate = DateTime.Now, ModifiedDate = DateTime.Now };
            WorkingHour thursday = new WorkingHour { BarberId = barberId, Day = DayOfWeek.Thursday, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(16, 30, 0), CreationDate = DateTime.Now, ModifiedDate = DateTime.Now };
            WorkingHour friday = new WorkingHour { BarberId = barberId, Day = DayOfWeek.Friday, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(13, 0, 0), CreationDate = DateTime.Now, ModifiedDate = DateTime.Now };
            WorkingHour saturday = new WorkingHour { BarberId = barberId, Day = DayOfWeek.Saturday, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(12, 30, 0), CreationDate = DateTime.Now, ModifiedDate = DateTime.Now };

            entities.Add(monday);
            entities.Add(tuesday);
            entities.Add(wednesday);
            entities.Add(thursday);
            entities.Add(friday);
            entities.Add(saturday);

            return entities;
        }
    }
}
