using RentalHub.Application.Interfaces;
using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Interfaces;
using RentalHub.Repository.Models;

namespace RentalHub.Application
{
    public class LogVeiculoService : RentalHubService, ILogVeiculoService
    {
        private readonly ILogVeiculoRepository _logVeiculoRepository;

        public LogVeiculoService(ILogVeiculoRepository logVeiculoRepository) : base(logVeiculoRepository)
        {
            _logVeiculoRepository = logVeiculoRepository;
        }

        public async Task<PageList<LogVeiculo>> GetAllLogs(PageParams pageParams)
        {
            try
            {
                return await _logVeiculoRepository.GetAllLogsAsync(pageParams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<LogVeiculo>> GetLog(PageParams pageParams, LogVeiculoDto logFilter)
        {
            try
            {
                return await _logVeiculoRepository.GetLogAsync(pageParams, logFilter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
