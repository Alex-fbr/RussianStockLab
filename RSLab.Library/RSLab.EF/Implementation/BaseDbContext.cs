using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace RSLab.EntityFramework.Implementation
{
    public abstract class BaseDbContext : DbContext, IBaseDbContext
    {
        public BaseDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public IDbContextTransaction BeginTransaction()
        {
            return Database.BeginTransaction();
        }

        public DbConnection GetDbConnection()
        {
            return Database.GetDbConnection();
        }  
    }
}
