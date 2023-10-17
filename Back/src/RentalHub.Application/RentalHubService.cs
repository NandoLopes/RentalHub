using RentalHub.Application.Interfaces;
using RentalHub.Domain;
using RentalHub.Repository.Interfaces;

namespace RentalHub.Application
{
    public class RentalHubService : IRentalHubService
    {
        private readonly IRentalHubRepository _repository;

        public RentalHubService(IRentalHubRepository repository)
        {
            _repository = repository;
        }

        public void Add<T>(T entity) where T : class
        {
            try
            {
                _repository.Add(entity);

                _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> Update<T>(T entity) where T : BaseEntity
        {
            try
            {
                _repository.Update(entity);

                if (await _repository.SaveChangesAsync())
                {
                    var result = await _repository.GetById<T>(entity.Id);

                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> GetById<T>(int id) where T : BaseEntity
        {
            try
            {
                return await _repository.GetById<T>(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> SetInactive<T>(int id) where T : BaseEntity
        {
            try
            {
                var item = await _repository.GetById<T>(id);

                if (item == null) return null;

                item.IsActive = false;

                _repository.Update(item);

                if (await _repository.SaveChangesAsync())
                {
                    var result = await _repository.GetById<T>(item.Id);

                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
