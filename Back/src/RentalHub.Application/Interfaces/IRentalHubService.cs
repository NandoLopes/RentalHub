using RentalHub.Domain;

namespace RentalHub.Application.Interfaces
{
    public interface IRentalHubService
    {
        void Add<T>(T entity) where T : class;
        Task<T> Update<T>(T entity) where T : BaseEntity;
        Task<T> GetById<T>(int id) where T : BaseEntity;
        Task<T> SetInactive<T>(int id) where T : BaseEntity;
    }
}
