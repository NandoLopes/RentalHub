using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Models;

namespace RentalHub.Repository.Interfaces
{
    public interface IVeiculoRepository : IRentalHubRepository
    {
        Task<PageList<Veiculo>> GetAllVeiculosAsync(PageParams pageParams);
        Task<PageList<Veiculo>> GetVeiculoByFilterAsync(PageParams pageParams, VeiculoGetDto filter);
    }
}
