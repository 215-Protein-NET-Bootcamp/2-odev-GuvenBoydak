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
            try
            {
                
            }
            catch (Exception)
            {

                throw new Exception($"Saving_Error {typeof(Country).Name}");
            }

            await _countryRepository.InsertAsync(model);

        }


        public async Task RemoveAsync(int id)
        {
            try
            {
                Country country = await _countryRepository.GetByIdAsync(id);
                _countryRepository.Remove(country);
            }
            catch (Exception)
            {

                throw new Exception($"Delete_Error {typeof(Country).Name}");
            }      
        }

        public async Task UpdateAsync(Country model)
        {
            try
            {
                await _countryRepository.UpdateAsync(model);
            }
            catch (Exception)
            {

                throw new Exception($"Update_Error {typeof(Country).Name}");
            }            
        }
    }
}
