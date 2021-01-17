using AceAutos.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AceAutos.Infrastructure.SQL
{
    public class DBContext : DbContext
    {
        //DBContext is not a database, it is an access point to the database and contains pieces of the database.
        public DBContext(DbContextOptions<DBContext> opt) : base(opt)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }

    }
}
