
using TodoApp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Contracts.Persistence;

namespace TodoApp.Persistence.Repositories
{
    public class GenericRepository<TEntity> :
         IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly DataBaseContext _context;

        public GenericRepository(DataBaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IReadOnlyList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public int Add(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public void DeletePermanent(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void DeletePermanent(int id)
        {
            var entity = GetById(id);
            DeletePermanent(entity);
        }

        public bool Exists(int id)
        {
            var entity = GetById(id);
            return entity != null;
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
