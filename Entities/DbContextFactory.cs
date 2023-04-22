using Entities.Context;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DbContextFactory : IDesignTimeDbContextFactory<SqlDbContext>
    {

        public SqlDbContext CreateDbContext(string[] args)
        {

            DbContextOptionsBuilder<SqlDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }

    }
}
