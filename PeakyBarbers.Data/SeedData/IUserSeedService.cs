using System.Threading.Tasks;

namespace PeakyBarbers.Data.SeedData
{
    public interface IUserSeedService
    {
        Task SeedUserAsync();

        Task SeedUserDataAsync(PeakyBarbersDbContext context);

    }
}