using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace PeakyBarbers.Data.Entities
{
    public class Barber : ApplicationUser
    {
        public int? YearsOfExperience { get; set; }
        public int? OverallRating { get; set; }
        public string? ProfileDescription { get; set; }

        public ICollection<WorkingHour> AllWorkingHours { get; set; }

        public ICollection<AppointmentSlot> AllAppointmentSlots { get; set; }
        
        public void Configure(EntityTypeBuilder<Barber> builder)
        {

            // BARBER-TO-WORKINGHOURS: 1-to-N relationship
            builder.HasMany(barber => barber.AllWorkingHours) // this entity: COLLECTION NAVIGATION PROPERTY
                .WithOne(workingHour => workingHour.Barber) // Relationship entity: NAVIGATION PROPERTY
                .HasForeignKey(workingHour => workingHour.BarberId) // Relationship entity: FOREIGN KEY
                .HasPrincipalKey(barber => barber.Id); // this entity: PRIMARY KEY

            // BARBER-TO-APPOINTMENTSLOTS: 1-to-N relationship
            builder.HasMany(barber => barber.AllAppointmentSlots) // this entity: COLLECTION NAVIGATION PROPERTY
                .WithOne(appSlot => appSlot.Barber) // Relationship entity: NAVIGATION PROPERTY
                .HasForeignKey(appSlot => appSlot.BarberId) // Relationship entity: FOREIGN KEY
                .HasPrincipalKey(barber => barber.Id); // this entity: PRIMARY KEY
        }
    }
}
