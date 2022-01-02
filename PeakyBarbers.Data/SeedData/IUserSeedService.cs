using PeakyBarbers.Data;
using System.Threading.Tasks;

namespace PetManager.Data.SeedData
{
    public interface IUserSeedService
    {
        Task SeedUserAsync();

        Task SeedUserDataAsync(PeakyBarbersDbContext context);

    }
}