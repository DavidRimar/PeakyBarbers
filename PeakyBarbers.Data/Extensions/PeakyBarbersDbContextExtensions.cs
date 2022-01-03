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
        public static async Task EnsureSeedDataForContextAsync(this PeakyBarbersDbContext context, IList<ApplicationUser> barberUserList)
        {
            
            int barberUserIdOne = barberUserList[0].Id;
            int barberUserIdTwo = barberUserList[1].Id;

            // APPOINTMENT SLOTS
            if (!context.AppointmentSlots.Any())
            {
                // Barber 1
                IList<AppointmentSlot> appSlotsList1 = SeedAppointmentSlotsForADay(barberUserIdOne, new DateTime(2022, 03, 24), 8);
                IList<AppointmentSlot> appSlotsList2 = SeedAppointmentSlotsForADay(barberUserIdOne, new DateTime(2022, 03, 25), 3);
                IList<AppointmentSlot> appSlotsList3 = SeedAppointmentSlotsForADay(barberUserIdOne, new DateTime(2022, 03, 27), 6);
                IList<AppointmentSlot> appSlotsList4 = SeedAppointmentSlotsForADay(barberUserIdOne, new DateTime(2022, 03, 28), 8);
                IList<AppointmentSlot> appSlotsList5 = SeedAppointmentSlotsForADay(barberUserIdOne, new DateTime(2022, 03, 29), 7);
                IList<AppointmentSlot> appSlotsList6 = SeedAppointmentSlotsForADay(barberUserIdOne, new DateTime(2022, 03, 30), 8);

                // Barber 2
                IList<AppointmentSlot> appSlotsList7 = SeedAppointmentSlotsForADay(barberUserIdTwo, new DateTime(2022, 03, 25), 5);
                IList<AppointmentSlot> appSlotsList8 = SeedAppointmentSlotsForADay(barberUserIdTwo, new DateTime(2022, 03, 29), 6);
                IList<AppointmentSlot> appSlotsList9 = SeedAppointmentSlotsForADay(barberUserIdTwo, new DateTime(2022, 03, 30), 6);

                context.AppointmentSlots.AddRange(appSlotsList1);
                context.AppointmentSlots.AddRange(appSlotsList2);
                context.AppointmentSlots.AddRange(appSlotsList3);
                context.AppointmentSlots.AddRange(appSlotsList4);
                context.AppointmentSlots.AddRange(appSlotsList5);
                context.AppointmentSlots.AddRange(appSlotsList6);
                context.AppointmentSlots.AddRange(appSlotsList7);
                context.AppointmentSlots.AddRange(appSlotsList8);
                context.AppointmentSlots.AddRange(appSlotsList9);

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

        private static IList<AppointmentSlot> SeedAppointmentSlotsForADay(int barberId, DateTime date, int numberOfAppointments)
        {

            IList<AppointmentSlot> entities = new List<AppointmentSlot>();

            TimeSpan startTime = new TimeSpan(8, 0, 0);
            TimeSpan endTime = new TimeSpan(9, 0, 0);

            for (int i = 0; i < numberOfAppointments; i++) {

                AppointmentSlot appSlot = new AppointmentSlot { BarberId = barberId, CustomerId = null, DayOfYear = date, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(8, 30, 0), BookingStatus = BookingStatus.Available, CreationDate = DateTime.Now, ModifiedDate = DateTime.Now };

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
