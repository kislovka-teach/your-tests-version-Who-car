using Microsoft.EntityFrameworkCore;
using SecondVersion.Abstractions;
using SecondVersion.Configurations;
using SecondVersion.Entities;

namespace SecondVersion.Repositories;

public class ModuleRepository(AppDbContext appDbContext) : IModuleRepository
{
    public async Task<Module> AddNewModuleAsync(Module module)
    {
        var result = await appDbContext.Modules.AddAsync(module);
        return result.Entity;
    }

    public async Task<Module?> GetModuleByIdAsync(int moduleId)
    {
        return await appDbContext.Modules.FirstOrDefaultAsync(module => module.Id == moduleId);
    }
}