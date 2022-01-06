using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PeakyBarbers.BLL.ExpressionMappers;
using PeakyBarbers.BLL.Services.DTOs;
using PeakyBarbers.Data;
using PeakyBarbers.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PeakyBarbers.BLL.Services
{
    public class BarbersService
    {
        // PROPERTIES
        public PeakyBarbersDbContext DbContext { get; }

        // CONSTRUCTOR
        public BarbersService(PeakyBarbersDbContext dbContext)
        {
            DbContext = dbContext;
        }

        

        // GET METHODs
        /// <summary>
        /// Gets All Barbers for the List view.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<BarberHeader>> GetAllBarbersListViewAsync()
        {
            return await DbContext.Barbers.Select(BarberSelectors.BarberHeaderSelector).OrderBy(b => b.FirstName).ToListAsync();
        }

        /// <summary>
        /// Gets a Barber by ID for the edit page.
        /// </summary>
        /// <returns></returns>
        public async Task<BarberEdit> GetBarberEditByIdAsync(int id)
        {
            return await DbContext.Barbers.Where(b => b.Id == id)
                                          .Select(BarberSelectors.BarberEditSelector)
                                          .SingleOrDefaultAsync();
        }

       

        /// <summary>
        /// Gets a Barber by ID for the individual details page.
        /// </summary>
        /// <returns></returns>
        public async Task<BarberDetails> GetBarberDetailsByIdAsync(int id)
        {
            // .Include(bd => bd.AllWorkingHours)
            return await DbContext.Barbers.Where(b => b.Id == id)
                                          .Select(BarberSelectors.BarberDetailsSelector)
                                          .SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets Working Hours for a Barber by Barber ID.
        /// </summary>
        /// <returns></returns>

        public async Task<IReadOnlyCollection<WorkingHoursHeader>> GetWorkingHoursForBarberAsync(int barberId)
        {
            // .Include(bd => bd.AllWorkingHours)
            return await DbContext.WorkingHours.Where(b => b.BarberId == barberId)
                                          .Select(WorkingHourSelectors.WorkingHoursSelector)
                                          .ToListAsync();
        }

        // POST OPERATIONS
        public async Task EditBarber(BarberEdit barberToEdit)
        {
            EntityEntry<Barber> entry = DbContext.Entry(await DbContext.Barbers.FindAsync(barberToEdit.Id));

            entry.CurrentValues.SetValues(barberToEdit);

            await DbContext.SaveChangesAsync();
        }
    }
}
