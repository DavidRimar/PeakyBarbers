using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeakyBarbers.Data.Enums;
using System;

namespace PeakyBarbers.Data.Entities
{
    public class AppointmentSlot : EntityBase, IEntityTypeConfiguration<AppointmentSlot>
    {
        // FK (Barber)
        public int BarberId { get; set; }

        // NAVIGATION PROPERTY (Barber)
        public Barber Barber { get; set; }

        // FK (Customer)
        public int? CustomerId { get; set; }

        // NAVIGATION PROPERTY (Customer)
        public Customer? Customer { get; set; }

        // FK (Service)
        public int? ServiceId { get; set; }

        // NAVIGATION PROPERTY (Service)
        public Service Service { get; set; }

        public DateTime DayOfYear { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public BookingStatus BookingStatus { get; set; }

        public void Configure(EntityTypeBuilder<AppointmentSlot> builder)
        {
            // Ensure No Overlapping Appointment slots on any given day for any given Barber: TODO

        }
    }
}
