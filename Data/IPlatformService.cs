using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformService
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform platform);
    }
}