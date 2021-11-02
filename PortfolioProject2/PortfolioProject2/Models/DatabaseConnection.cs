using System;
using Microsoft.EntityFrameworkCore;
using System;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Models
{
    public class DatabaseConnection : DbContext
    {
        public DbSet<Titles> titles { get; set; }
        
        private readonly string connectionString = "host=rawdata.ruc.dk;port=5432;database=raw8;username=raw8;password=utuBOPUw";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseNpgsql(connectionString);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Titles>().ToTable("titles");
            modelBuilder.Entity<Titles>().Property(x => x.titlesid).HasColumnName("titleid");
            modelBuilder.Entity<Titles>().Property(x => x.titletype).HasColumnName("titletype");
            modelBuilder.Entity<Titles>().Property(x => x.primarytitle).HasColumnName("primarytitle");
            modelBuilder.Entity<Titles>().Property(x => x.originaltitle).HasColumnName("originaltitle");
            modelBuilder.Entity<Titles>().Property(x => x.isadult).HasColumnName("isadult");
            modelBuilder.Entity<Titles>().Property(x => x.startyear).HasColumnName("startyear");
            modelBuilder.Entity<Titles>().Property(x => x.endyear).HasColumnName("endyear");
            modelBuilder.Entity<Titles>().Property(x => x.runtime).HasColumnName("runtime");
            modelBuilder.Entity<Titles>().Property(x => x.genres).HasColumnName("genres");

        }
    }
}
