using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace HJC.James.Domain.EntityFramework
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {      

        public AppDbContext CreateDbContext(string[] args)
        {

            //string basePath = AppDomain.CurrentDomain.BaseDirectory;

            //string envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(basePath)
            //    .AddJsonFile("appsettings.json")
            //    .AddJsonFile($"appsettings.{envName}.json", true)
                .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>();

            var connectionString = configuration.GetConnectionString("Default");

            builder.UseMySql(connectionString);

            return new AppDbContext(builder.Options);
        }
    }
}
