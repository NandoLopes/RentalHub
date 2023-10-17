using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RentalHub.Domain;
using RentalHub.Domain.DTOs;
using RentalHub.Repository.Contexts;
using RentalHub.Repository.Interfaces;
using RentalHub.Repository.Models;

namespace RentalHub.Repository
{
    public class LocadoraRepository : RentalHubRepository, ILocadoraRepository
    {
        private readonly RentalHubContext _context;

        public LocadoraRepository(RentalHubContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PageList<Locadora>> GetAllLocadorasAsync(PageParams pageParams)
        {
            IQueryable<Locadora> query = _context.Locadoras
                .Include(l => l.Endereco)
                .Include(l => l.Veiculos)
                    .ThenInclude(v => v.Modelo)
                        .ThenInclude(m => m.Montadora)
                 .Where(x => x.IsActive);

            query = CheckActives(query, true);

            query = query.AsNoTracking()
                         .OrderBy(v => v.Id);

            return await PageList<Locadora>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        public async Task<PageList<Locadora>> GetLocadoraByFilterAsync(PageParams pageParams, LocadoraGetDto filter)
        {
            IQueryable<Locadora> query = _context.Locadoras
                .Include(l => l.Endereco)
                .Include(l => l.Veiculos)
                    .ThenInclude(v => v.Modelo)
                        .ThenInclude(m => m.Montadora);

            query = query.AsNoTracking()
                         .Where(v => (filter.Id == 0 || v.Id == filter.Id) &&
                                     (filter.Telefone == 0 || v.Telefone == filter.Telefone) &&
                                     (filter.EnderecoId == 0 || v.EnderecoId == filter.EnderecoId) &&
                                     (string.IsNullOrEmpty(filter.NomeFantasia) || v.NomeFantasia.ToLower().Contains(filter.NomeFantasia.ToLower())) &&
                                     (string.IsNullOrEmpty(filter.RazaoSocial) || v.RazaoSocial.ToLower().Contains(filter.RazaoSocial.ToLower())) &&
                                     (string.IsNullOrEmpty(filter.CNPJ) || v.CNPJ.ToLower().Contains(filter.CNPJ.ToLower())) &&
                                     (string.IsNullOrEmpty(filter.Email) || v.Email.ToLower().Contains(filter.Email.ToLower())) &&
                                     (string.IsNullOrEmpty(filter.RazaoSocial) || v.RazaoSocial.ToLower().Contains(filter.RazaoSocial.ToLower()))
                                );

            query = CheckActives(query, filter.IsActive);

            query = query.AsNoTracking()
                         .OrderBy(v => v.Id);

            return await PageList<Locadora>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        private IQueryable<Locadora> CheckActives(IQueryable<Locadora> query, bool activeStatus)
        {
            return query = query.AsNoTracking()
                         .Where(l => l.IsActive == activeStatus);
        }
    }
}
