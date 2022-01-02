using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace PeakyBarbers.Data.Entities
{
    public class WorkingHour : EntityBase, IEntityTypeConfiguration<WorkingHour>
    {
        // FK (Barber)
        public int BarberId { get; set; }

        // NAVIGATION PROPERTY (Barber)
        public Barber Barber { get; set; }

        public DayOfWeek Day { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public void Configure(EntityTypeBuilder<WorkingHour> builder)
        {
            // Ensure Unique Relationship Record (A Barber cannot have multiple working schedule for a day)
            builder.HasIndex(ws => new { ws.BarberId, ws.Day })
                    .IsUnique();

            // TODO: On any given day StartTime < EndTime!
        }
    }
}
