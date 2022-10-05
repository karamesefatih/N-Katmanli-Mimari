using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        { 
        
        
        
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Bu şekide primary key yapılabilir modelBuilder.Entity<Product>().HasKey(x => x.Id)

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
          // Tek TEK VERMEYE GEREK YOK  modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id=1,
                Color="Kırmızı",
                Height = 100,
                Width = 200,
                ProducId=1,


            },
            new ProductFeature()
            {
                Id = 2,
                Color = "Mavi",
                Height = 200,
                Width = 300,
                ProducId = 1,


            });

            
            
            base.OnModelCreating(modelBuilder);
        }


    }
}
