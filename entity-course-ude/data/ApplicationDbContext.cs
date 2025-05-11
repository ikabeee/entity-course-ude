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
            // modelBuilder.Entity<ProductTag>().HasKey(pt => new { pt.Tag_Id, pt.Product_Id });
            //Data seed
            // var category5 = new Category() { Category_Id = 33, Name = "Category 5", CreatedAt = new DateTime(2021, 11, 18), Active = true };
            // var category6 = new Category() { Category_Id = 34, Name = "Category 6", CreatedAt = new DateTime(2021, 11, 18), Active = true };
            // modelBuilder.Entity<Category>().HasData(new Category[] { category6 });
            // Fluent API for category
            modelBuilder.Entity<Category>().HasKey(category => category.Category_Id);
            modelBuilder.Entity<Category>().Property(category => category.Name).IsRequired();
            modelBuilder.Entity<Category>().Property(category => category.CreatedAt).HasColumnType("date");
            //Fluent API for Products
            modelBuilder.Entity<Product>().HasKey(product => product.Product_Id);
            modelBuilder.Entity<Product>().Property(product => product.Name).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Product>().Property(product => product.Description).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Product>().Property(product => product.Date).IsRequired().HasColumnType("date");
            //Fluent API Table Name and Column Name
            modelBuilder.Entity<Product>().ToTable("Tbl_Product");
            modelBuilder.Entity<Category>().Property(product => product.Name).HasColumnName("Title");

            //Fluent API for User
            modelBuilder.Entity<User>().HasKey(user => user.Id);
            modelBuilder.Entity<User>().Property(user => user.Name).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<User>().Property(user => user.Email).IsRequired().HasMaxLength(50);


            //Fluent API for User Detail
            modelBuilder.Entity<UserDetail>().HasKey(userDetail => userDetail.UserDetail_Id);
            modelBuilder.Entity<UserDetail>().Property(userDetail => userDetail.Code).IsRequired();

            //Fluent API for Tag
            modelBuilder.Entity<Tag>().HasKey(tag => tag.Tag_Id);
            modelBuilder.Entity<Tag>().Property(tag => tag.Date).IsRequired().HasColumnType("date");
            //Fluent API with relationships
            //One to One
            modelBuilder.Entity<User>().HasOne(user => user.UserDetail).WithOne(userDetail => userDetail.User).HasForeignKey<User>("UserDetail_Id");
            //One to Many
            modelBuilder.Entity<Product>().HasOne(product => product.Category).WithMany(category => category.Product).HasForeignKey(product => product.Category_Id);
            //Many to Many
            modelBuilder.Entity<ProductTag>().HasKey(productTag => new { productTag.Tag_Id, productTag.Product_Id });
            modelBuilder.Entity<ProductTag>().HasOne(productTag => productTag.Product).WithMany(product => product.ProductTag).HasForeignKey(productTag => productTag.Product_Id);
            modelBuilder.Entity<ProductTag>().HasOne(productTag => productTag.Tag).WithMany(tag => tag.ProductTag).HasForeignKey(productTag => productTag.Tag_Id);
            base.OnModelCreating(modelBuilder);
        }

        /*
        * Cuando se crea una nueva clase
        * Cuando se agregue una nueva propiedad
        * Cuando modifique un valor de campo en la clase
        */
    }
}