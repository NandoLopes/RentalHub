using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Models;

namespace RentalHub.Application.Interfaces
{
    public interface ILogVeiculoService : IRentalHubService
    {
        Task<PageList<LogVeiculo>> GetAllLogs(PageParams pageParams);
        Task<PageList<LogVeiculo>> GetLog(PageParams pageParams, LogVeiculoDto logFilter);
    }
}
