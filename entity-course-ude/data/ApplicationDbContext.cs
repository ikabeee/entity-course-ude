using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entity_course_ude.Models;
using Microsoft.EntityFrameworkCore;

namespace entity_course_ude.data
{
    // Inherence
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        // Escribir modelos
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<ProductTag> ProductTag { get; set; }


        //Many to Many
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //API Fluent
            modelBuilder.Entity<ProductTag>().HasKey(pt => new { pt.Tag_Id, pt.Product_Id });
            //Data seed
            var category5 = new Category() { Category_Id=33, Name="Category 5", CreatedAt= new DateTime(2021,11,18), Active=true };
            var category6 = new Category() { Category_Id=34, Name="Category 6", CreatedAt= new DateTime(2021,11,18), Active=true };
            modelBuilder.Entity<Category>().HasData(new Category[] { category6 });
            base.OnModelCreating(modelBuilder);
        }

        /*
        * Cuando se crea una nueva clase
        * Cuando se agregue una nueva propiedad
        * Cuando modifique un valor de campo en la clase
        */
    }
}