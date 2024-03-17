using SecondVersion.Entities;

namespace SecondVersion.Abstractions;

public interface IModuleRepository
{
    public Task AddNewModuleAsync(Module module);
    public Task<List<Module>?> GetAllModulesAsync(Func<Module, bool>? predicate = null);
    public Task<Module?> GetModuleByIdAsync(int moduleId);
}