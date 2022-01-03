using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace PeakyBarbers.Data.SeedData
{
    public class RoleSeedService : IRoleSeedService
    {
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public RoleSeedService(RoleManager<IdentityRole<int>> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task SeedRoleAsync()
        {
            // 1. Barber
            if (!await roleManager.RoleExistsAsync("Barber"))
            {

                await roleManager.CreateAsync(new IdentityRole<int> { Name = "Barber" });
            }

            // 2. Admin
            if (!await roleManager.RoleExistsAsync("Admin"))
            {

                await roleManager.CreateAsync(new IdentityRole<int> { Name = "Admin" });
            }

            // 3. Customer
            if (!await roleManager.RoleExistsAsync("Customer"))
            {

                await roleManager.CreateAsync(new IdentityRole<int> { Name = "Customer" });
            }
        }
    }
}
