using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeakyBarbers.Data.Entities;
using PeakyBarbers.Data.Enums;

namespace PeakyBarbers.Data.SeedData
{
    public class SeedDataConfiguration
    {
        public static void ConfigureSeedData(ModelBuilder modelBuilder)
        {

            // initialise creation date
            var creationDate = new DateTime(2022, 01, 02, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149);

            // services
            modelBuilder.Entity<Service>().HasData(
                WithAudit(new Service { Id = 1, ServiceName = "Peaky Blood Cut", ServiceDescription = "Straight Razor Head Shave", ServiceFee = 10, ApproximateServiceDurationInMinutes = 15}),
                WithAudit(new Service { Id = 2, ServiceName = "Executive", ServiceDescription = "Haircut, neck shave, extended therapeutic scalp massage, shampoo and conditioner.", ServiceFee = 50, ApproximateServiceDurationInMinutes = 60 }),
                WithAudit(new Service { Id = 3, ServiceName = "Classic", ServiceDescription = "Complete grooming with neck trim.", ServiceFee = 25, ApproximateServiceDurationInMinutes = 20 }),
                WithAudit(new Service { Id = 4, ServiceName = "Young Men's Choice", ServiceDescription = "A basic haircut for the younger gentlemen.", ServiceFee = 15, ApproximateServiceDurationInMinutes = 15 }),
                WithAudit(new Service { Id = 5, ServiceName = "Color Camouflage", ServiceDescription = "Hair dyeing and natural colouring.", ServiceFee = 40, ApproximateServiceDurationInMinutes = 60 })
                );


            // entity base settings
            T WithAudit<T>(T entity) where T : EntityBase
            {
                entity.CreationDate = entity.ModifiedDate = creationDate;
                return entity;
            }
        }
    }
}
