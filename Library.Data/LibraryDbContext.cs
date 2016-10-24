using Library.Data.Entities;
using Library.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() 
            : base("LibraryConnection") { }

        public DbSet<Book> Books { get; set; }

        static LibraryDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryDbContext, Configuration>());
        }
    }
}
