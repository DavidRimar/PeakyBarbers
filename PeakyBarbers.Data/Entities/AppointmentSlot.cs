using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

        public DateTime DayOfYear { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public void Configure(EntityTypeBuilder<AppointmentSlot> builder)
        {
            // Ensure No Overlapping Appointment slots on any given day: TODO

        }
    }
}
