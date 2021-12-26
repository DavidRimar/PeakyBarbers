using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakyBarbers.Data.Entities
{
    public class Barber : ApplicationUser
    {
        public int? YearsOfExperience { get; set; }
        public int? OverallRating { get; set; }

        public ICollection<WorkingHour> AllWorkingHours { get; set; }

        //public ICollection<WorkingHours> AllWorkingHours { get; set; }
        
        public void Configure(EntityTypeBuilder<Barber> builder)
        {

            // BARBER-TO-WORKINGHOURS: 1-to-N relationship
            builder.HasMany(barber => barber.AllWorkingHours) // this entity: COLLECTION NAVIGATION PROPERTY
                .WithOne(workingHour => workingHour.Barber) // Relationship entity: NAVIGATION PROPERTY
                .HasForeignKey(workingHour => workingHour.BarberId) // Relationship entity: FOREIGN KEY
                .HasPrincipalKey(barber => barber.Id); // this entity: PRIMARY KEY
        }
    }
}
