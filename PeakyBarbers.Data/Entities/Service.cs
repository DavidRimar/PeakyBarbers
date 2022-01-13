using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakyBarbers.Data.Entities
{
    public class Service : EntityBase, IEntityTypeConfiguration<Service>
    {
        public string ServiceName { get; set; }

        public string ServiceDescription { get; set; }

        public int ApproximateServiceDurationInMinutes { get; set; }

        public decimal ServiceFee { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<AppointmentSlot> AllAppointmentSlots { get; set; }

        public void Configure(EntityTypeBuilder<Service> builder)
        {
            // ServicetFee decimal precision
            builder.Property(pet => pet.ServiceFee).HasColumnType("decimal(18,2)");

            // Service-TO-APPOINTMENTSLOTS: 1-to-N relationship
            builder.HasMany(s => s.AllAppointmentSlots) // this entity: COLLECTION NAVIGATION PROPERTY
                .WithOne(appSlot => appSlot.Service) // Relationship entity: NAVIGATION PROPERTY
                .HasForeignKey(appSlot => appSlot.ServiceId) // Relationship entity: FOREIGN KEY
                .HasPrincipalKey(s => s.Id) // this entity: PRIMARY KEY
                .OnDelete(DeleteBehavior.Restrict); // dont delete related appointments
        }
    }
}
