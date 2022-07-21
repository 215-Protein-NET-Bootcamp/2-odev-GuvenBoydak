using BootcampHomework.Entities;
using BootcampHomeWork.DataAccess;

namespace BootcampHomeWork.Business
{
    public class DpCountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public DpCountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IEnumerable<Country>> GetActivesAsync()
        {
            return await _countryRepository.GetActivesAsync();

        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
           return await _countryRepository.GetAllAsync();

            
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await _countryRepository.GetByIdAsync(id);

        }

        public async Task InsertAsync(Country model)
        {
           await _countryRepository.InsertAsync(model);
        }


        public async Task RemoveAsync(int id)
        {
            Country country = await _countryRepository.GetByIdAsync(id);
            _countryRepository.Remove(country);
        }

        public async Task UpdateAsync(Country model)
        {
            await _countryRepository.UpdateAsync(model);
        }
    }
}
