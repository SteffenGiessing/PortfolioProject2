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
            
            
            modelBuilder.Entity<Titles>().ToTable("Episodes");
            modelBuilder.Entity<Titles>().Property(x => x.TitlesId).HasColumnName("EpisodeId");
            modelBuilder.Entity<Titles>().Property(x => x.TitleType).HasColumnName("SeriesId");
            modelBuilder.Entity<Titles>().Property(x => x.PrimaryTitle).HasColumnName("SeasonNumber");
            modelBuilder.Entity<Titles>().Property(x => x.OriginalTitle).HasColumnName("EpisodeNumber");
            modelBuilder.Entity<Titles>().ToTable("Genre");
            modelBuilder.Entity<Titles>().Property(x => x.TitlesId).HasColumnName("TitleId");
            modelBuilder.Entity<Titles>().Property(x => x.TitleType).HasColumnName("Genres");
            modelBuilder.Entity<Titles>().ToTable("Omdb_Data");
            modelBuilder.Entity<Titles>().Property(x => x.TitlesId).HasColumnName("TitleId");
            modelBuilder.Entity<Titles>().Property(x => x.TitleType).HasColumnName("Poster");
            modelBuilder.Entity<Titles>().Property(x => x.PrimaryTitle).HasColumnName("Awards");
            modelBuilder.Entity<Titles>().Property(x => x.OriginalTitle).HasColumnName("Plot");
            modelBuilder.Entity<Titles>().ToTable("Person_In_Title");
            modelBuilder.Entity<Titles>().Property(x => x.OriginalTitle).HasColumnName("TitleId");
            modelBuilder.Entity<Titles>().Property(x => x.IsAdult).HasColumnName("Ordering");
            modelBuilder.Entity<Titles>().Property(x => x.StartYear).HasColumnName("Pid");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("Role");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("Job");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("CharName");
            modelBuilder.Entity<Titles>().ToTable("Person_Info");
            modelBuilder.Entity<Titles>().Property(x => x.StartYear).HasColumnName("Pid");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("PrimaryName");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("BirthYear");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("DeathYear");
            modelBuilder.Entity<Titles>().ToTable("Person_Known_For");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("Pid");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("KnownForTitle");
            modelBuilder.Entity<Titles>().ToTable("Person_Profession");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("Pid");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("Profession");
            modelBuilder.Entity<Titles>().ToTable("Ratings");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("TitleId");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("AverageRating");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("NumVotes");
            modelBuilder.Entity<Titles>().ToTable("TitleKnownAs");
            modelBuilder.Entity<Titles>().Property(x => x.TitlesId).HasColumnName("TitleId");
            modelBuilder.Entity<Titles>().Property(x => x.TitleType).HasColumnName("Ordering");
            modelBuilder.Entity<Titles>().Property(x => x.PrimaryTitle).HasColumnName("Title");
            modelBuilder.Entity<Titles>().Property(x => x.OriginalTitle).HasColumnName("Region");
            modelBuilder.Entity<Titles>().Property(x => x.IsAdult).HasColumnName("Language");
            modelBuilder.Entity<Titles>().Property(x => x.StartYear).HasColumnName("Types");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("Attributes");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("IsOriginalTitle");
            modelBuilder.Entity<Titles>().ToTable("Titles");  
            modelBuilder.Entity<Titles>().Property(x => x.TitlesId).HasColumnName("TitleId");
            modelBuilder.Entity<Titles>().Property(x => x.TitleType).HasColumnName("TitleType");
            modelBuilder.Entity<Titles>().Property(x => x.PrimaryTitle).HasColumnName("PrimaryTitle");
            modelBuilder.Entity<Titles>().Property(x => x.OriginalTitle).HasColumnName("OriginalTitle");
            modelBuilder.Entity<Titles>().Property(x => x.IsAdult).HasColumnName("IsAdult");
            modelBuilder.Entity<Titles>().Property(x => x.StartYear).HasColumnName("StartYear");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("EndYear");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("Runtime");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("Genres");
            modelBuilder.Entity<Titles>().ToTable("User_BookMarks"); 
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("UserId");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("TitleId");
            modelBuilder.Entity<Titles>().ToTable("User_Comments"); 
            modelBuilder.Entity<Titles>().Property(x => x.IsAdult).HasColumnName("CommentText");
            modelBuilder.Entity<Titles>().Property(x => x.StartYear).HasColumnName("UserId");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("TitleId");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("CommentTime");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("CommentId");
            modelBuilder.Entity<Titles>().ToTable("User_History"); 
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("SearchId");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("SearchText");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("UserId");
            modelBuilder.Entity<Titles>().ToTable("User_Ratings"); 
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("TitleId");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("UserId");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("RateNumber");
            modelBuilder.Entity<Titles>().ToTable("User_User"); 
            modelBuilder.Entity<Titles>().Property(x => x.PrimaryTitle).HasColumnName("UserId");
            modelBuilder.Entity<Titles>().Property(x => x.OriginalTitle).HasColumnName("FirstName");
            modelBuilder.Entity<Titles>().Property(x => x.IsAdult).HasColumnName("LastName");
            modelBuilder.Entity<Titles>().Property(x => x.StartYear).HasColumnName("UserName");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("EmailAddress");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("PasswordSalt");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("PasswordHash");
            modelBuilder.Entity<Titles>().ToTable("Wi"); 
            modelBuilder.Entity<Titles>().Property(x => x.StartYear).HasColumnName("TitleId");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("Word");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("Field");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("Lexeme");
        }   
    }
}
