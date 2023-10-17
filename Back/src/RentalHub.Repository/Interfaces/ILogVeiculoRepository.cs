using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Models;

namespace RentalHub.Repository.Interfaces
{
    public interface ILogVeiculoRepository : IRentalHubRepository
    {
        Task<PageList<LogVeiculo>> GetAllLogsAsync(PageParams pageParams);
        Task<PageList<LogVeiculo>> GetLogAsync(PageParams pageParams, LogVeiculoDto logFilter);
    }
}
