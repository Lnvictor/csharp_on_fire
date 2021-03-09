using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Contexts
{
    public class ProductInfoContext: DbContext
    {
        public DbSet<Product> products {get; set;}

        public ProductInfoContext(DbContextOptions<ProductInfoContext> options): base(options)
        {
            // Database.EnsureCreated();
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Product>()
        //         .HasData(
        //             new Product(){
        //                 Id = 1,
        //                 Name = "Sal",
        //                 Description = "Salga as Paradas",
        //                 Value = float.Parse("18.2"),
        //             }
        //         );
        //     base.OnModelCreating(modelBuilder);
        // }

    }
}