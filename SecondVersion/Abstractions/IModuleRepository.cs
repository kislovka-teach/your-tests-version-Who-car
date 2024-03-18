using SecondVersion.Entities;

namespace SecondVersion.Abstractions;

public interface IModuleRepository
{
    public Task<Module> AddNewModuleAsync(Module module);
    public Task<Module?> GetModuleByIdAsync(int moduleId);
}