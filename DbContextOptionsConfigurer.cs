using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HJC.James.Domain.EntityFramework
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AppDbContext> dbContextOptions, string connectionString)
        {
            /* This is the single point to configure DbContextOptions for AppDbContext */
            dbContextOptions.UseMySql(connectionString);
        }
    }
}
