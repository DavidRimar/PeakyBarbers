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

        public int ApproximateServiceDurationInMinutes { get; set; }

        public decimal ServiceFee { get; set; }

        public void Configure(EntityTypeBuilder<Service> builder)
        {
            // ServicetFee decimal precision
            builder.Property(pet => pet.ServiceFee).HasColumnType("decimal(18,2)");
        }
    }
}
