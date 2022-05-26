using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepo : IPlatformRepo
{
    private readonly AppDbContext _dbContext;
    
    public PlatformRepo(AppDbContext context)
    {
        _dbContext = context;
    }
    
    public bool SaveChanges() => (_dbContext.SaveChanges() >= 0);

    public void CreatePlatform(Platform platform)
    {
        if (platform == null)
        {
            throw new ArgumentNullException(nameof(platform));
        }

        _dbContext.Add(platform);
    }

    public IEnumerable<Platform> GetAllPlatforms() => _dbContext.Platforms.ToList();

    public Platform? GetPlatformById(int id) => _dbContext.Platforms.FirstOrDefault(p => p.Id == id);
}