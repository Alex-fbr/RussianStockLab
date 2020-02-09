using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace RSLab.EntityFramework
{
    public interface IBaseDbContext
    {
        IDbContextTransaction BeginTransaction();

        int SaveChanges();

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        DbConnection GetDbConnection();
    }
}
