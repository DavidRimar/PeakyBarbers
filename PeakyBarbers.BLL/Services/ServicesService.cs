using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PeakyBarbers.BLL.ExpressionMappers;
using PeakyBarbers.BLL.Services.DTOs;
using PeakyBarbers.Data;
using PeakyBarbers.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakyBarbers.BLL.Services
{
    public class ServicesService
    {
        // PROPERTIES
        public PeakyBarbersDbContext DbContext { get; }

        // CONSTRUCTOR
        public ServicesService(PeakyBarbersDbContext dbContext)
        {
            DbContext = dbContext;
        }

        // GET METHODs
        /// <summary>
        /// Gets All Services for the List view.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<ServiceHeader>> GetAllServicesListViewAsync()
        {
            return await DbContext.Services.Select(ServiceExpressions.ServiceHeaderSelector).ToListAsync();
        }

        public async Task<ServiceDelete> GetServiceToDeleteByIdAsync(int id)
        {
            return await DbContext.Services.Where(b => b.Id == id)
                                        .Select(ServiceExpressions.ServiceDeleteSelector)
                                        .SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets a Service by ID for the edit page.
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceEdit> GetServiceToEditByIdAsync(int id)
        {
            return await DbContext.Services.Where(b => b.Id == id)
                                          .Select(ServiceExpressions.ServiceEditSelector)
                                          .SingleOrDefaultAsync();
        }

        // POST METHODs
        /// <summary>
        /// Edit a Service.
        /// </summary>
        /// <param name="serviceToEdit"></param>
        /// <returns></returns>
        public async Task PostEditService(ServiceEdit serviceToEdit)
        {
            EntityEntry<Service> entry = DbContext.Entry(await DbContext.Services.FindAsync(serviceToEdit.Id));

            entry.CurrentValues.SetValues(serviceToEdit);

            await DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete a Service.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task PostDeleteService(int id)
        {
            DbContext.Services.Remove(new Service { Id = id });
            await DbContext.SaveChangesAsync();
        }

        public async Task<bool> PostCreateService(ServiceCreate serviceCreate)
        {
            Service newService = new Service { 
                                                ServiceName = serviceCreate.ServiceName, 
                                                ServiceFee = serviceCreate.ServiceFee,
                                                ApproximateServiceDurationInMinutes = serviceCreate.ApproximateServiceDurationInMinutes,
                                                ServiceDescription = serviceCreate.ServiceDescription,
                                                CreationDate = DateTime.Now,
                                                ModifiedDate = DateTime.Now
                                            };

            DbContext.Add(newService);

            await DbContext.SaveChangesAsync();

            return true;

        }
    }
}
