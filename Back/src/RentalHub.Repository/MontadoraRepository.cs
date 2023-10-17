using Microsoft.EntityFrameworkCore;
using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Contexts;
using RentalHub.Repository.Interfaces;
using RentalHub.Repository.Models;

namespace RentalHub.Repository
{
    public class MontadoraRepository : RentalHubRepository, IMontadoraRepository
    {
        private readonly RentalHubContext _context;

        public MontadoraRepository(RentalHubContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PageList<Montadora>> GetAllMontadorasAsync(PageParams pageParams)
        {
            IQueryable<Montadora> query = _context.Montadoras
                .Include(m => m.Modelos)
                    .ThenInclude(m => m.Veiculos); //NOTE: EF + Newtonsoft causa erro de loop ao incluir Montadora tambem.

            query = CheckActives(query, true);

            query = query.AsNoTracking()
                         .OrderBy(v => v.Id);

            return await PageList<Montadora>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        public async Task<PageList<Montadora>> GetMontadoraByFilterAsync(PageParams pageParams, MontadoraGetDto filter)
        {
            IQueryable<Montadora> query = _context.Montadoras
                .Include(m => m.Modelos)
                    .ThenInclude(m => m.Veiculos);

            query = query.AsNoTracking()
                         .Where(m => (filter.Id == 0 || m.Id == filter.Id) &&
                                     (string.IsNullOrEmpty(filter.Nome) || m.Nome.ToLower().Contains(filter.Nome.ToLower()))
                         );

            query = CheckActives(query, filter.IsActive);

            query = query.AsNoTracking()
                         .OrderBy(m => m.Id);

            return await PageList<Montadora>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        private IQueryable<Montadora> CheckActives(IQueryable<Montadora> query, bool activeStatus)
        {
            return query = query.AsNoTracking()
                         .Where(m => m.IsActive == activeStatus);
        }
    }
}
