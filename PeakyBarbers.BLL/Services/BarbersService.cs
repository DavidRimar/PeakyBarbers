using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PeakyBarbers.BLL.ExpressionMappers;
using PeakyBarbers.BLL.Services.DTOs;
using PeakyBarbers.Data;
using PeakyBarbers.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PeakyBarbers.BLL.Services
{
    public class BarbersService
    {
        

        // PROPERTIES
        public PeakyBarbersDbContext DbContext { get; }

        private readonly UserManager<ApplicationUser> _userManager;

        // CONSTRUCTOR
        public BarbersService(PeakyBarbersDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            DbContext = dbContext;
            _userManager = userManager;
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
        /// Gets a Barber by ID for the delete page.
        /// </summary>
        /// <returns></returns>
        public async Task<BarberDelete> GetBarberToDeleteByIdAsync(int id)
        {
            return await DbContext.Barbers.Where(b => b.Id == id)
                                        .Select(BarberSelectors.BarberDeleteSelector)
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

        public async Task<bool> PostCreateBarber(BarberCreate barberToCreate)
        {
            Barber newBarber = new Barber
            {
                FirstName = barberToCreate.FirstName,
                LastName = barberToCreate.LastName,
                ProfileDescription = barberToCreate.ProfileDescription,
                OverallRating = barberToCreate.OverallRating,
                Gender = barberToCreate.Gender,
                YearsOfExperience = barberToCreate.YearsOfExperience,
                UserName = barberToCreate.Email,
                Email = barberToCreate.Email,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var result = await _userManager.CreateAsync(newBarber, barberToCreate.Password);

            // add claims
            var claimsToAdd = new List<Claim>() {
                    new Claim(ClaimTypes.GivenName, newBarber.FirstName),
                    new Claim(ClaimTypes.Surname, newBarber.LastName)
                };

            var claimsResult = await _userManager.AddClaimsAsync(newBarber, claimsToAdd);

            await _userManager.AddToRoleAsync(newBarber, "Barber");

            return true;
        }

        /// <summary>
        /// Deletes a Barber by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> PostDeleteBarber(int? id)
        {
            Barber barber = await DbContext.Barbers.Where(b => b.Id == id).SingleAsync();
            DbContext.Barbers.Remove(barber);
            await DbContext.SaveChangesAsync();

            return true;
        }

    }
}
