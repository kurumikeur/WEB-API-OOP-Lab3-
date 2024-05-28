using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Storage.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Db.Storage.MS_SQL
{
    public class SqlServerContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private const string DbContextString = "Server=localhost,1433;Database=CenterOb;User ID=sa;Password=<YourStrong@Passw0rd>;MultipleActiveResultsSets=true;TrustServerCertification=True";
        public DataContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<DataContext>();

            optionBuilder.UseSqlServer("", b => b.MigrationsAssembly(typeof(SqlServerContextFactory).Namespace));

            return new DataContext(optionBuilder.Options);
        }
    }
}
