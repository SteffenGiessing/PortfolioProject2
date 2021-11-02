using System;
using Microsoft.EntityFrameworkCore;
using System;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Models
{
    public class DatabaseConnection : DbContext
    {
        public DbSet<Titles> Titles { get; set; }
        
        private readonly string connectionString = "host=rawdata.ruc.dk;port=5432;database=raw8;username=raw8;password=utuBOPUw";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseNpgsql(connectionString, options => options.EnableRetryOnFailure());
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Titles>().ToTable("titles");
            modelBuilder.Entity<Titles>().Property(x => x.TitlesId).HasColumnName("titleid");
            modelBuilder.Entity<Titles>().Property(x => x.TitleType).HasColumnName("titletype");
            modelBuilder.Entity<Titles>().Property(x => x.PrimaryTitle).HasColumnName("primarytitle");
            modelBuilder.Entity<Titles>().Property(x => x.OriginalTitle).HasColumnName("originaltitle");
            modelBuilder.Entity<Titles>().Property(x => x.IsAdult).HasColumnName("isadult");
            modelBuilder.Entity<Titles>().Property(x => x.StartYear).HasColumnName("startyear");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("endyear");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("runtime");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("genres");

        }
    }
}
