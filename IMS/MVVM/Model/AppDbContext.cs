using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IMS.MVVM.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Product> Products { get; set; }

        private string _dbPath;

        public AppDbContext()
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _dbPath = Path.Combine(folder, "ims.db");
            Database.EnsureCreated(); // auto-creates if doesn't exist
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }
    }
}
