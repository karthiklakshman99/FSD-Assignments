using CompanyManagement.Models;
using CompanyManagement.Repositories.Interfaces;

namespace CompanyManagement.Repositories
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IRepository<Developer> _developerRepository;

        public DeveloperService(IRepository<Developer> developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public async Task<IEnumerable<Developer>> GetAllDevelopersAsync()
        {
            return await _developerRepository.GetAllAsync();
        }

        public async Task<Developer> GetDeveloperByIdAsync(int id)
        {
            return await _developerRepository.GetByIdAsync(id);
        }

        public async Task AddDeveloperAsync(Developer developer)
        {
            await _developerRepository.AddAsync(developer);
        }

        public async Task UpdateDeveloperAsync(Developer developer)
        {
            await _developerRepository.UpdateAsync(developer);
        }

        public async Task DeleteDeveloperAsync(int id)
        {
            await _developerRepository.DeleteAsync(id);
        }
    }

}
