using System.Collections.Generic;
using System.Linq.Expressions;
using domain;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Persistence.GenericRepository;
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8766
#pragma warning disable CS1998
public class GenericRepository<TEntity,TKey> : IGenericRepository<TEntity,TKey> where TEntity : BaseClass<TKey>
{
    #region Constructor

    public GenericRepository(AppContext context)
    {
        Context = context;
        this.dbSet = context.Set<TEntity>();
    }

    #endregion /Constructor

    #region Properties

    internal AppContext Context { get; }
    internal DbSet<TEntity> dbSet { get; }

    #endregion /Properties

    #region Methods

    #region Query Methods

    public virtual async Task<TEntity>? Get(
        Expression<Func<TEntity, bool>> filter = null,
        Expression<Func<TEntity, TEntity>>? select = null, string includeProperties = "",
        bool isTrackable = false, CancellationToken token = default)
    {
        IQueryable<TEntity> query = dbSet;
        query = QueryGenerator(query, filter, null, includeProperties, isTrackable);
        try
        {
            if (select != null) return query.Select(select).FirstOrDefault();
            return query.FirstOrDefault();
        }
        catch (Exception e)
        {
            Console.WriteLine(e); // Can Log And Remove Console.WriteLine Or Anything You Like To Do
            return null;
        }
 
    }

    public virtual async Task<TOutPut>? Get<TOutPut>(
        Expression<Func<TEntity, bool>> filter = null, 
        Expression<Func<TEntity, TOutPut>>? select = null, string includeProperties = "",
        bool isTrackable = false, CancellationToken token = default) where TOutPut : class
    {
        IQueryable<TEntity> query = dbSet;
        query = QueryGenerator(query, filter, null, includeProperties, isTrackable);
        try
        {
            if (select != null) return query.Select(select).FirstOrDefault();
            return query.Adapt<TOutPut>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e); // Can Log And Remove Console.WriteLine
            return null;
        }
    }

    public virtual async Task<IEnumerable<TEntity>>? GetAll(Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Expression<Func<TEntity, TEntity>>? select = null, string includeProperties = "",
        bool isTrackable = false, CancellationToken token = default)
    {
        IQueryable<TEntity> query = dbSet;
        query = QueryGenerator(query, filter, orderBy, includeProperties, isTrackable);
        try
        {
            if (select != null) return query.Select(select).ToList();
            return query.ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e); // Can Log And Remove Console.WriteLine
            return null;
        }
    }
    public virtual async Task<IEnumerable<TOutPut>>? GetAll<TOutPut>(Expression<Func<TEntity, bool>> filter = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
        , Expression<Func<TEntity, TOutPut>>? select = null, string includeProperties = "",
        bool isTrackable = false, CancellationToken token = default) where TOutPut : class
    {
        IQueryable<TEntity> query = dbSet;
        query = QueryGenerator(query, filter, orderBy, includeProperties, isTrackable);
        try
        {
            if (select != null) return query.Select(select).ToList();
            return query.ProjectToType<TOutPut>().ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e); // Can Log And Remove Console.WriteLine
            return null;
        }
    }
    #endregion /Query Methods

    #region Command Methods

    public virtual void Insert(TEntity entity)
    {
        dbSet.Add(entity);
    }

    public virtual void Remove(TEntity entity)
    {
        if (Context.Entry(entity).State == EntityState.Detached)
        {
            dbSet.Attach(entity);
        }
        dbSet.Remove(entity);
    }
    public virtual void Update(TEntity entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        Context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    #endregion /Command Methods

    #region Utility Methods
    /// <summary>
    /// Include Other Models Base On string Entered
    /// Like ("Category,Category.User" )
    /// Then Category And User In Category Include To Query
    /// </summary>
    /// <param name="query"></param>
    /// <param name="includeProperties"></param>
    /// <returns></returns>
    private IQueryable<TEntity> QueryWithIncludeProperties(IQueryable<TEntity> query,
        string includeProperties)
    {
        foreach (var includeProperty in includeProperties.Split
                     (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }
        return query;
    }
    /// <summary>
    /// Filter Query Depend On Parameters 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="filter"></param>
    /// <param name="orderBy"></param>
    /// <param name="includeProperties"></param>
    /// <param name="isTrackable"></param>
    /// <returns></returns>
    private  IQueryable<TEntity> QueryGenerator(IQueryable<TEntity> query,
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "",
        bool isTrackable = false)
    {
        if (filter != null) query = query.Where(filter);

        if (!string.IsNullOrWhiteSpace(includeProperties))
            query = QueryWithIncludeProperties(query, includeProperties);

        if (!isTrackable) query = query.AsNoTracking();

        if (orderBy != null) query = orderBy(query);
        return query;
    }

    #endregion /Utility Methods

    #endregion /Methods
}
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8766
#pragma warning restore CS1998