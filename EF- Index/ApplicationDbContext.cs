

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEF
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EFCore; Integrated Security = True");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // make the value of the index is unique using flount API and give it name
            modelBuilder.Entity<Blog>()
                   .HasIndex(b => b.Url)
                   .IsUnique()
                   .HasDatabaseName("Index_Url_Test")
                   .HasFilter(null);



            //modelBuilder.Entity<Person>()
            //    .HasIndex(p => new { p.FristName, p.LastName });


        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Blog> Tags { get; set; }
        public DbSet<Person> Persons { get; set; } 

    }


   

    public class Post
    {
        public int PostId { get; set; }
        public int BlogId { get; set; }

        public Blog Blog { get; set; }



    }
    // make the value of the index is unique using data anotation and give it name

   // [Index(nameof(Url) , IsUnique = true,  Name = "Index_Url")]
    public class Blog 
    {
        public int BlogId { get; set; }

        public string Url { get; set; }

        public List<Post> Posts { get; set; }   

    }
    //Composite Index

     [Index(nameof(FristName) , nameof(LastName))]

    public class Person
    {
        [Key]
        public int PostId { get; set; }

        public String FristName { get; set; }

        public String LastName { get; set; }



    }
}
