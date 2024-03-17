using Microsoft.EntityFrameworkCore;
using SecondVersion.Abstractions;
using SecondVersion.Configurations;
using SecondVersion.Entities;

namespace SecondVersion.Repositories;

public class ModuleRepository(AppDbContext appDbContext) : IModuleRepository
{
    public async Task AddNewModuleAsync(Module module)
    {
        await appDbContext.Modules.AddAsync(module);
        await appDbContext.SaveChangesAsync();
    }

    public async Task<List<Module>?> GetAllModulesAsync(Func<Module, bool>? predicate = null)
    {
        if (predicate is null)
            return await appDbContext.Modules.ToListAsync();
        return appDbContext.Modules.Where(predicate).ToList();
    }

    public async Task<Module?> GetModuleByIdAsync(int moduleId)
    {
        return await appDbContext.Modules.FirstOrDefaultAsync(module => module.Id == moduleId);
    }
}