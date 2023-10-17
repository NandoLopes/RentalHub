using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Models;

namespace RentalHub.Repository.Interfaces
{
    public interface IModeloRepository : IRentalHubRepository
    {
        Task<PageList<Modelo>> GetAllModelosAsync(PageParams pageParams);
        Task<PageList<Modelo>> GetModeloByFilterAsync(PageParams pageParams, ModeloGetDto filter);
    }
}
