using Microsoft.EntityFrameworkCore;
using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Contexts;
using RentalHub.Repository.Interfaces;
using RentalHub.Repository.Models;

namespace RentalHub.Repository
{
    public class LogVeiculoRepository : RentalHubRepository, ILogVeiculoRepository
    {
        private readonly RentalHubContext _context;

        public LogVeiculoRepository(RentalHubContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PageList<LogVeiculo>> GetAllLogsAsync(PageParams pageParams)
        {
            IQueryable<LogVeiculo> query = _context.LogsVeiculos
                .Include(l => l.Locadora)
                .Include(l => l.Veiculo);

            query = CheckActives(query, true);

            query = query.AsNoTracking()
                         .OrderBy(v => v.Id);

            return await PageList<LogVeiculo>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        public async Task<PageList<LogVeiculo>> GetLogAsync(PageParams pageParams, LogVeiculoDto filter)
        {
            IQueryable<LogVeiculo> query = _context.LogsVeiculos
                .Include(l => l.Locadora)
                .Include(l => l.Veiculo);

            query = query.AsNoTracking()
                         .Where(l => (filter.Id == 0 || l.Id == filter.Id) &&
                                     (filter.VeiculoId == 0 || l.VeiculoId == filter.VeiculoId) &&
                                     (filter.LocadoraId == 0 || l.LocadoraId == filter.LocadoraId) &&
                                     (filter.DataInicio == null || (l.DataInicio != null && l.DataInicio.Value.Date == filter.DataInicio.Value.Date)) &&
                                     (filter.DataFim == null || (l.DataFim != null && l.DataFim.Value.Date == filter.DataFim.Value.Date))
                    );

            query = CheckActives(query, filter.IsActive);

            query = query.AsNoTracking()
                         .OrderByDescending(v => v.Id);

            return await PageList<LogVeiculo>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        private IQueryable<LogVeiculo> CheckActives(IQueryable<LogVeiculo> query, bool activeStatus)
        {
            return query = query.AsNoTracking()
                         .Where(m => m.IsActive == activeStatus);
        }
    }
}
