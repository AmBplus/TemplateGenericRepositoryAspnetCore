using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shared;

public interface IGenericRepository<TEntity,TKey> where TEntity : class
{
    Task<TEntity> Get(
          Expression<Func<TEntity,bool>> filter = null ,
          Expression<Func<TEntity, TEntity>>? select = null, string include = "" ,
         bool isTrackable = false, CancellationToken token = default ) ;

 
    Task<TOutPut> Get<TOutPut>(
        Expression<Func<TEntity, bool>> filter = null, 
        Expression<Func<TEntity, TOutPut>>? select = null, string include = "",
        bool isTrackable = false, CancellationToken token = default) where TOutPut : class ;

    Task<IEnumerable<TEntity>> GetAll(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
        , Expression<Func<TEntity, TEntity>>? select = null, string include = ""
        , bool isTrackable = false, CancellationToken token = default);
    Task<IEnumerable<TOutPut>> GetAll<TOutPut>(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
        , Expression<Func<TEntity, TOutPut>>? select = null, string include = ""
        , bool isTrackable = false, CancellationToken token = default) where TOutPut : class;
 
    void Insert(TEntity entity);
    void Remove(TEntity entity);
    void Update(TEntity entityToUpdate);
}

