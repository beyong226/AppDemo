using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using HJC.James.Domain.Entities;
using HJC.James.Domain.Entities.Roles;
using HJC.James.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HJC.James.Domain.EntityFramework
{
    
    public class AppDbContext : AbpDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }

        //public virtual DbSet<SysUser> Users { get; set; }
        //public virtual DbSet<SysRole> Roles { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql(@"server=localhost;User Id =root; password=Hjc@123456;Database=testcap");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            GetModelTypes().ToList().ForEach(e => modelBuilder.Model.GetOrAddEntityType(e));
            base.OnModelCreating(modelBuilder);
        }

        #region  辅助方法

        /// <summary>
        ///     Public class, not Abstract, not GenericType
        /// </summary>
        public static IEnumerable<Type> GetModelTypes()
        {
            Assembly assembly = typeof(AppEntityModule).Assembly;
            return assembly.GetTypes().Where(IsModelType);
        }

        /// <summary>
        ///     Public class, not Abstract, not GenericType
        /// </summary>
        public static bool IsModelType(Type type)
        {
            Type baseType = typeof(IEntity<>);
            return Array.Exists(
                   type.GetInterfaces(),
                   t =>
                       t.IsGenericType &&
                       t.GetGenericTypeDefinition() == baseType
                   ) &&
                   !type.IsAbstract &&
                   !type.IsGenericType &&
                   type.IsClass &&
                   type.IsPublic;
        }

        #endregion
    }

    public class AppDbContextConfig
    {
        public static DbContextOptions<AppDbContext> GetOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(@"server=localhost;User Id =root; password=Hjc@123456;Database=testcap");
           
            return optionsBuilder.Options;
        }
    }

    public enum WriteAndRead
    {
        Write,
        Read
    }
}
