using Microsoft.EntityFrameworkCore;
using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Contexts;
using RentalHub.Repository.Interfaces;
using RentalHub.Repository.Models;

namespace RentalHub.Repository
{
    public class ModeloRepository : RentalHubRepository, IModeloRepository
    {
        private readonly RentalHubContext _context;

        public ModeloRepository(RentalHubContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PageList<Modelo>> GetAllModelosAsync(PageParams pageParams)
        {
            IQueryable<Modelo> query = _context.Modelos;

            query = query.AsNoTracking()
                         .Include(m => m.Montadora)
                         .Include(m => m.Veiculos)
                         .OrderBy(m => m.Id);

            query = CheckActives(query, true);

            return await PageList<Modelo>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        public async Task<PageList<Modelo>> GetModeloByFilterAsync(PageParams pageParams, ModeloGetDto filter)
        {
            IQueryable<Modelo> query = _context.Modelos
                .Include(m => m.Montadora)
                .Include(m => m.Veiculos)
                .OrderBy(m => m.Id);

            query = query.AsNoTracking()
                         .Where(m => (filter.Id == 0 || m.Id == filter.Id) &&
                                     (filter.MontadoraId == 0 || m.MontadoraId == filter.MontadoraId) &&
                                     (string.IsNullOrEmpty(filter.Nome) || m.Nome.ToLower().Contains(filter.Nome.ToLower())) &&
                                     (string.IsNullOrEmpty(filter.NomeMontadora) || m.Montadora.Nome.ToLower().Contains(filter.NomeMontadora.ToLower()))
                                );

            query = CheckActives(query, filter.IsActive);

            query = query.AsNoTracking()
                         .OrderBy(v => v.Id);

            return await PageList<Modelo>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        private IQueryable<Modelo> CheckActives(IQueryable<Modelo> query, bool activeStatus)
        {
            return query = query.AsNoTracking()
                         .Where(m => m.IsActive == activeStatus);
        }
    }
}
