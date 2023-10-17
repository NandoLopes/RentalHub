using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Models;

namespace RentalHub.Repository.Interfaces
{
    public interface IMontadoraRepository : IRentalHubRepository
    {
        Task<PageList<Montadora>> GetAllMontadorasAsync(PageParams pageParams);
        Task<PageList<Montadora>> GetMontadoraByFilterAsync(PageParams pageParams, MontadoraGetDto filter);
    }
}
