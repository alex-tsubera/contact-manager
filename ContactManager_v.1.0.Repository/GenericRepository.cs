using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager_v._1._0.Repository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity: class
    {
        protected DbContext _entities;
        protected IDbSet<TEntity> _dbSet;
        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable<TEntity>();
        }

        public IEnumerable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> query = _dbSet.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public TEntity Delete(object id)
        {
            var entity = _dbSet.Find(id);
            return _dbSet.Remove(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            return _dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _entities.SaveChanges();
        }
    }
}
