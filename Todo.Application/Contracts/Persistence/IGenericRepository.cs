
using TodoApp.Domain.Common;

namespace TodoApp.Application.Contracts.Persistence
{
    public interface IGenericRepository<TEntity> :
        IDisposable where TEntity : BaseEntity
    {
        TEntity GetById(int id);
        IReadOnlyList<TEntity> GetAll();
        int Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void DeletePermanent(TEntity entity);
        void DeletePermanent(int id);
        bool Exists(int id);
    }
}
