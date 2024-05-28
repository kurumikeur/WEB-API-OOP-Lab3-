using Microsoft.EntityFrameworkCore;
using Db.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Storage.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }
    public virtual DbSet<Center> Centers { get; set; }

    public virtual DbSet<User> Users { get; set; }

}
