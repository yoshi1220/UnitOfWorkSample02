using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public  class PlutoContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = new SqliteConnectionStringBuilder { DataSource = @"..\db\UnitOfWorkSample01.db" }.ToString();
            optionsBuilder.UseSqlite(new SqliteConnection(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
