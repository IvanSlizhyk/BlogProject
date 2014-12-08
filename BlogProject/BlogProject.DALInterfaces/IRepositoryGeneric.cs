using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlogProject.Core;

namespace BlogProject.DALInterfaces
{
    public interface IRepositoryGeneric<TEntity, in TKey> : IBaseRepository where TEntity : Entity
    {
        void Create(TEntity value);
        void Update(TEntity value);
        void Remove(TEntity value);
        TEntity GetEntiyById(TKey id);
        TEntity FindEntity(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> All();
        IQueryable<TEntity> FilteEntities(Expression<Func<TEntity, bool>> predicate);
    }
}
