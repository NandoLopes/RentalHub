using Microsoft.EntityFrameworkCore;
using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Contexts;
using RentalHub.Repository.Interfaces;
using RentalHub.Repository.Models;

namespace RentalHub.Repository
{
    public class VeiculoRepository : RentalHubRepository, IVeiculoRepository
    {
        private readonly RentalHubContext _context;

        public VeiculoRepository(RentalHubContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PageList<Veiculo>> GetAllVeiculosAsync(PageParams pageParams)
        {
            IQueryable<Veiculo> query = _context.Veiculos
                .Include(v => v.Locadora)
                .Include(v => v.Modelo);

            query = CheckActives(query, true);

            query = query.AsNoTracking()
                         .OrderBy(v => v.Id);

            return await PageList<Veiculo>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        public async Task<PageList<Veiculo>> GetVeiculoByFilterAsync(PageParams pageParams, VeiculoGetDto filter)
        {
            IQueryable<Veiculo> query = _context.Veiculos
                .Include(v => v.Modelo)
                    .ThenInclude(m => m.Montadora)
                .Include(v => v.Locadora)
                    .ThenInclude(l => l.Endereco);

            query = query.AsNoTracking()
                         .Where(v => (filter.Id == 0 || v.Id == filter.Id) &&
                                     (filter.NumeroPortas == 0 || v.NumeroPortas == filter.NumeroPortas) &&
                                     (filter.ModeloId == 0 || v.ModeloId == filter.ModeloId) &&
                                     (filter.AnoModelo == null || v.AnoModelo == filter.AnoModelo) &&
                                     (filter.AnoFabricacao == null || v.AnoFabricacao.Date == filter.AnoFabricacao.Value.Date) &&
                                     (string.IsNullOrEmpty(filter.Cor) || v.Cor.ToLower().Contains(filter.Cor.ToLower())) &&
                                     (string.IsNullOrEmpty(filter.Placa) || v.Placa.ToLower().Contains(filter.Placa.ToLower())) &&
                                     (string.IsNullOrEmpty(filter.Chassi) || v.Chassi.ToLower().Contains(filter.Chassi.ToLower())) &&
                                     (filter.LocadoraId == 0 || v.LocadoraId == filter.LocadoraId) &&
                                     (filter.DataCadastro == null || v.DataCadastro.Date == filter.DataCadastro.Value.Date)
                         );

            query = CheckActives(query, filter.IsActive);

            query = query.AsNoTracking()
                         .OrderBy(v => v.Id);

            return await PageList<Veiculo>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        private IQueryable<Veiculo> CheckActives(IQueryable<Veiculo> query, bool activeStatus)
        {
            return query = query.AsNoTracking()
                         .Where(m => m.IsActive == activeStatus);
        }   
    }
}
