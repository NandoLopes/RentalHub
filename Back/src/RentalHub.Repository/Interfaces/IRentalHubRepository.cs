namespace RentalHub.Repository.Interfaces
{
    public interface IRentalHubRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;

        Task<T> GetById<T>(int id) where T : class;

        Task<bool> SaveChangesAsync();
    }
}
