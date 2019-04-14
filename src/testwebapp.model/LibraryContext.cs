using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testwebapp.model
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class LibraryContext : DbContext
    {
        public LibraryContext()
            //Reference the name of your connection string ( WebAppCon )  
            : base("WebAppCon") { }

        public DbSet<Book> Book { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
        }*/

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Publisher>().HasKey(e => e.ID).Property(e => e.Name).IsRequired();
            //modelBuilder.Entity<Publisher>().Prop

            modelBuilder.Entity<Book>().HasKey(e => e.ISBN).Property(e => e.Title).IsRequired();
            modelBuilder.Entity<Book>().HasOptional(d => d.Publisher).WithMany(p => p.Books);
        }
    }
}
