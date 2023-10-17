using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Models;

namespace RentalHub.Repository.Interfaces
{
    public interface ILocadoraRepository : IRentalHubRepository
    {
        Task<PageList<Locadora>> GetAllLocadorasAsync(PageParams pageParams);
        Task<PageList<Locadora>> GetLocadoraByFilterAsync(PageParams pageParams, LocadoraGetDto filter);
    }
}
