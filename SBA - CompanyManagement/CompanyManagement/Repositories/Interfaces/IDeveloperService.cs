using CompanyManagement.Models;

namespace CompanyManagement.Repositories.Interfaces
{
    public interface IDeveloperService
    {
        Task<IEnumerable<Developer>> GetAllDevelopersAsync();
        Task<Developer> GetDeveloperByIdAsync(int id);
        Task AddDeveloperAsync(Developer developer);
        Task UpdateDeveloperAsync(Developer developer);
        Task DeleteDeveloperAsync(int id);
    }

}
