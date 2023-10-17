using RentalHub.Repository.Contexts;
using RentalHub.Repository.Interfaces;

namespace RentalHub.Repository
{
    public class RentalHubRepository : IRentalHubRepository
    {
        private readonly RentalHubContext _context;

        public RentalHubRepository(RentalHubContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<T> GetById<T>(int id) where T : class
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
