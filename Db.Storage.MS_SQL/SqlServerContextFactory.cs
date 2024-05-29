using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Db.Storage.Database;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Db.Storage.MS_SQL
{
    public class SqlServerContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public const string DbContextString = "Server=localhost,1433;Database=Db;User ID=sa;Password=<YourStrong@Passw0rd>;MultipleActiveResultSets=true;TrustServerCertificate=True";
        public DataContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<DataContext>();

            optionBuilder.UseSqlServer(DbContextString, b => b.MigrationsAssembly("Db.Storage.MS_SQL"));

            return new DataContext(optionBuilder.Options);
        }
    }
}
