using Orders.Shared.Entities;
using Orders.Shared.Responses;

namespace Orders.Backend.Respositories.Interfaces
{
    public interface ICountriesRepository
    {

        Task<ActionResponse<Country>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<Country>>> GetAsync();
    }
}
