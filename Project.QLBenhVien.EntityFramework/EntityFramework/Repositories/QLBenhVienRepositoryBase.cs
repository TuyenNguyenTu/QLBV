using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Project.QLBenhVien.EntityFramework.Repositories
{
    public abstract class QLBenhVienRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<QLBenhVienDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected QLBenhVienRepositoryBase(IDbContextProvider<QLBenhVienDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class QLBenhVienRepositoryBase<TEntity> : QLBenhVienRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected QLBenhVienRepositoryBase(IDbContextProvider<QLBenhVienDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
