using System;
namespace eCommerce.Contracts.Repositories
{
    public interface IRepositoryBase<TEntity>
     where TEntity : class
    {
        void Commit();
        void Delete(object id);
        void Delete(TEntity entity);
        void Dispose();
        System.Linq.IQueryable<TEntity> GetAll();
        System.Linq.IQueryable<TEntity> GetAll(object filter);
        TEntity GetById(object id);
        TEntity GetFullObject(object id);
        System.Linq.IQueryable<TEntity> GetPaged(int top = 20, int skip = 0, object orderBy = null, object filter = null);
        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
}
