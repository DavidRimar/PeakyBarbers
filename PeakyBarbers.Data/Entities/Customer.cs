using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace PeakyBarbers.Data.Entities
{
    public class Customer : ApplicationUser
    {
        public bool PremiumDiscountEligible { get; set; }
        public bool StandardDiscountEligible { get; set; }
        public ICollection<AppointmentSlot> AllAppointmentSlots { get; set; }
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            // Customer-TO-APPOINTMENTSLOTS: 1-to-N relationship
            builder.HasMany(customer => customer.AllAppointmentSlots) // this entity: COLLECTION NAVIGATION PROPERTY
                .WithOne(appSlot => appSlot.Customer) // Relationship entity: NAVIGATION PROPERTY
                .HasForeignKey(appSlot => appSlot.CustomerId) // Relationship entity: FOREIGN KEY
                .HasPrincipalKey(customer => customer.Id); // this entity: PRIMARY KEY
        }
    }
}
