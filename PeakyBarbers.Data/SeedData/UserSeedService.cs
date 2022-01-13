using Microsoft.AspNetCore.Identity;
using PeakyBarbers.Data.Entities;
using PeakyBarbers.Data.Enums;
using PeakyBarbers.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PeakyBarbers.Data.SeedData
{
    public class UserSeedService : IUserSeedService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserSeedService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task SeedUserAsync()
        {
            // SEED STAFF USERS
            await initBarbersWithRole("Barber");

            // SEED PERSON USERS
            await initCustomersWithRole("Customer");

            // SEED ALL USER RELATED DATA
            /*
            IList<ApplicationUser> barberUserList = await userManager.GetUsersInRoleAsync("Barber");
            IList<ApplicationUser> customerUserList = await userManager.GetUsersInRoleAsync("Customer");
            ConfigureUserRelatedSeedData(new ModelBuilder(), barberUserList, customerUserList);
            */
        }

        public async Task SeedUserDataAsync(PeakyBarbersDbContext context)
        {

            // SEED ALL USER RELATED DATA
            IList<ApplicationUser> barberUserList = await userManager.GetUsersInRoleAsync("Barber");
            IList<ApplicationUser> customerUserList = await userManager.GetUsersInRoleAsync("Customer");
            await PeakyBarbersDbContextExtensions.EnsureSeedDataForContextAsync(context, barberUserList, customerUserList);
        }

        private void CheckSuccess(IdentityResult userResult, IdentityResult roleResult)
        {
            if (!userResult.Succeeded || !roleResult.Succeeded)
            {

                // Error handling
                throw new ApplicationException("Unable to create user!" + string.Join(", ", userResult.Errors.Concat(roleResult.Errors).Select(e => e.Description)));
            }
        }

        private async Task initBarbersWithRole(string role)
        {
            if (!(await userManager.GetUsersInRoleAsync(role)).Any())
            {

                // initialize Barbers
                ApplicationUser tomShelby = new Barber
                {
                    FirstName = "Thomas",
                    LastName = "Shelby",
                    DateOfBirth = new DateTime(1991, 08, 11),
                    Gender = Gender.Male,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    ProfileDescription = "Mr. Thomas Shelby specialises in hair dying with 15 years of experience.",
                    OverallRating = 9,
                    YearsOfExperience = 15,
                    UserName = "thomasshelby@example.com",
                    Email = "thomasshelby@example.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true
                };

                ApplicationUser johnShelby = new Barber
                {
                    FirstName = "John",
                    LastName = "Shelby",
                    DateOfBirth = new DateTime(1991, 08, 11),
                    Gender = Gender.Male,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    ProfileDescription = "Mr. John Shelby specialises in hair dying with 15 years of experience.",
                    OverallRating = 7,
                    YearsOfExperience = 5,
                    UserName = "johnshelby@example.com",
                    Email = "johnshelby@example.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true
                };

                ApplicationUser arthurShelby = new Barber
                {
                    FirstName = "Arthur",
                    LastName = "Shelby",
                    DateOfBirth = new DateTime(1991, 08, 11),
                    Gender = Gender.Male,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    ProfileDescription = "Mr. Arthur Shelby specialises in hair dying with 15 years of experience.",
                    OverallRating = 8,
                    YearsOfExperience = 11,
                    UserName = "arthurshelby@example.com",
                    Email = "arthurshelby@example.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true
                };

                // create user with password
                var createResultOne = await userManager.CreateAsync(tomShelby, "Password123!");
                var createResultTwo = await userManager.CreateAsync(johnShelby, "Password123!");
                var createResultThree = await userManager.CreateAsync(arthurShelby, "Password123!");

                // confirm registration if required
                if (userManager.Options.SignIn.RequireConfirmedAccount)
                {

                    // confirm registration
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(tomShelby);
                    var result = await userManager.ConfirmEmailAsync(tomShelby, code);

                    var code2 = await userManager.GenerateEmailConfirmationTokenAsync(johnShelby);
                    var result2 = await userManager.ConfirmEmailAsync(johnShelby, code2);

                    var code3 = await userManager.GenerateEmailConfirmationTokenAsync(arthurShelby);
                    var result3 = await userManager.ConfirmEmailAsync(arthurShelby, code3);
                }

                // add claims
                var claims1 = new List<Claim>() {
                    new Claim(ClaimTypes.GivenName, tomShelby.FirstName),
                    new Claim(ClaimTypes.Surname, tomShelby.LastName)
                };
                var claims2 = new List<Claim>() {
                    new Claim(ClaimTypes.GivenName, johnShelby.FirstName),
                    new Claim(ClaimTypes.Surname, johnShelby.LastName)
                };
                var claims3 = new List<Claim>() {
                    new Claim(ClaimTypes.GivenName, arthurShelby.FirstName),
                    new Claim(ClaimTypes.Surname, arthurShelby.LastName)
                };

                var claimsResult1 = await userManager.AddClaimsAsync(tomShelby, claims1);
                var claimsResult2 = await userManager.AddClaimsAsync(johnShelby, claims1);
                var claimsResult3 = await userManager.AddClaimsAsync(arthurShelby, claims1);

                // add role to user
                var addRoleResultOne = await userManager.AddToRoleAsync(tomShelby, role);
                var addRoleResultTwo = await userManager.AddToRoleAsync(johnShelby, role);
                var addRoleResultThree = await userManager.AddToRoleAsync(arthurShelby, role);

                // add Thomas Shelby to admin role
                await userManager.AddToRoleAsync(tomShelby, "Admin");

                // check success
                CheckSuccess(createResultOne, addRoleResultOne);
                CheckSuccess(createResultTwo, addRoleResultTwo);
                CheckSuccess(createResultThree, addRoleResultThree);
            }
        }

        private async Task initCustomersWithRole(string role)
        {
            if (!(await userManager.GetUsersInRoleAsync(role)).Any())
            {

                // initialize Persons
                ApplicationUser applicationUserPersonOne = new Customer
                {
                    FirstName = "Jamie",
                    LastName = "Vardy",
                    DateOfBirth = new DateTime(1990, 08, 11),
                    Gender = Gender.Male,
                    CustomerCategory = CustomerCategory.Basic,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    UserName = "jamievardy@example.com",
                    Email = "jamievardy@example.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true
                };

                ApplicationUser applicationUserPersonTwo = new Customer
                {
                    FirstName = "Jack",
                    LastName = "Grealish",
                    DateOfBirth = new DateTime(1995, 12, 13),
                    Gender = Gender.Male,
                    CustomerCategory = CustomerCategory.Premium,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    UserName = "jackgrealish@example.com",
                    Email = "jackgrealish@example.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true
                };

                // create user with password
                var createResultOne = await userManager.CreateAsync(applicationUserPersonOne, "Password123!");
                var createResultTwo = await userManager.CreateAsync(applicationUserPersonTwo, "Password123!");

                // confirm registration if required
                if (userManager.Options.SignIn.RequireConfirmedAccount)
                {

                    // confirm registration
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(applicationUserPersonOne);
                    var result = await userManager.ConfirmEmailAsync(applicationUserPersonOne, code);

                    var code2 = await userManager.GenerateEmailConfirmationTokenAsync(applicationUserPersonTwo);
                    var result2 = await userManager.ConfirmEmailAsync(applicationUserPersonTwo, code2);
                }

                // add role to user
                var addRoleResultOne = await userManager.AddToRoleAsync(applicationUserPersonOne, role);
                var addRoleResultTwo = await userManager.AddToRoleAsync(applicationUserPersonTwo, role);

                // check user
                CheckSuccess(createResultOne, addRoleResultOne);
                CheckSuccess(createResultTwo, addRoleResultTwo);
            }
        }
    }
}