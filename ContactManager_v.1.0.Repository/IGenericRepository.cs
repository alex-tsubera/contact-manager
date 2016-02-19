using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager_v._1._0.Repository
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        TEntity Delete(object id);
        TEntity Delete(TEntity entity);
        void Update(TEntity entity);
        void Save();
    }
}
