using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Unosquare.Data.Models
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
             .Where(x => x.GetInterfaces().Any(type =>
                 type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
             .ToList();

            //Get all the IEntityTypeConfiguration and execute the HasData()
            foreach (var type in types)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
                var entityType = type.GetGenericInterfaceParameter(typeof(IEntityTypeConfiguration<>));
                modelBuilder.Entity(entityType).HasData();
            }
            base.OnModelCreating(modelBuilder);
        }



    }

    public static class TypeExtensions
    {
        public static System.Type GetGenericInterfaceParameter(this System.Type concreteType, System.Type interfaceType)
        {
            var _interface = concreteType
                .GetInterfaces()
                .Single(y => y.IsGenericType && y.GetGenericTypeDefinition() == interfaceType);

            return _interface.GetGenericArguments().First();
        }
    }
}
