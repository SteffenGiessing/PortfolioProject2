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
            
            
            modelBuilder.Entity<Titles>().ToTable("episodes");
            modelBuilder.Entity<Titles>().Property(x => x.TitlesId).HasColumnName("episodeid");
            modelBuilder.Entity<Titles>().Property(x => x.TitleType).HasColumnName("seriesid");
            modelBuilder.Entity<Titles>().Property(x => x.PrimaryTitle).HasColumnName("seasonnumber");
            modelBuilder.Entity<Titles>().Property(x => x.OriginalTitle).HasColumnName("episodenumber");
            modelBuilder.Entity<Titles>().ToTable("genre");
            modelBuilder.Entity<Titles>().Property(x => x.TitlesId).HasColumnName("titleid");
            modelBuilder.Entity<Titles>().Property(x => x.TitleType).HasColumnName("genres");
            modelBuilder.Entity<Titles>().ToTable("omdb_Data");
            modelBuilder.Entity<Titles>().Property(x => x.TitlesId).HasColumnName("titleid");
            modelBuilder.Entity<Titles>().Property(x => x.TitleType).HasColumnName("poster");
            modelBuilder.Entity<Titles>().Property(x => x.PrimaryTitle).HasColumnName("awards");
            modelBuilder.Entity<Titles>().Property(x => x.OriginalTitle).HasColumnName("plot");
            modelBuilder.Entity<Titles>().ToTable("person_in_title");
            modelBuilder.Entity<Titles>().Property(x => x.OriginalTitle).HasColumnName("titleid");
            modelBuilder.Entity<Titles>().Property(x => x.IsAdult).HasColumnName("ordering");
            modelBuilder.Entity<Titles>().Property(x => x.StartYear).HasColumnName("pid");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("role");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("job");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("charname");
            modelBuilder.Entity<Titles>().ToTable("person_info");
            modelBuilder.Entity<Titles>().Property(x => x.StartYear).HasColumnName("pid");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("primaryname");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("birthyear");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("deathyear");
            modelBuilder.Entity<Titles>().ToTable("person_known_for");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("pid");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("knownfortitle");
            modelBuilder.Entity<Titles>().ToTable("person_profession");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("pid");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("profession");
            modelBuilder.Entity<Titles>().ToTable("ratings");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("titleid");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("averagerating");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("numvotes");
            modelBuilder.Entity<Titles>().ToTable("title_known_as");
            modelBuilder.Entity<Titles>().Property(x => x.TitlesId).HasColumnName("titleid");
            modelBuilder.Entity<Titles>().Property(x => x.TitleType).HasColumnName("ordering");
            modelBuilder.Entity<Titles>().Property(x => x.PrimaryTitle).HasColumnName("title");
            modelBuilder.Entity<Titles>().Property(x => x.OriginalTitle).HasColumnName("region");
            modelBuilder.Entity<Titles>().Property(x => x.IsAdult).HasColumnName("language");
            modelBuilder.Entity<Titles>().Property(x => x.StartYear).HasColumnName("types");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("attributes");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("isoriginaltitle");
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
            modelBuilder.Entity<Titles>().ToTable("user_bookmarks"); 
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("userid");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("titleid");
            modelBuilder.Entity<Titles>().ToTable("user_comments"); 
            modelBuilder.Entity<Titles>().Property(x => x.IsAdult).HasColumnName("commenttext");
            modelBuilder.Entity<Titles>().Property(x => x.StartYear).HasColumnName("userid");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("titleid");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("commenttime");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("commentid");
            modelBuilder.Entity<Titles>().ToTable("user_history"); 
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("searchid");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("searchtext");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("userid");
            modelBuilder.Entity<Titles>().ToTable("user_ratings"); 
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("titleid");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("userid");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("ratenumber");
            modelBuilder.Entity<Titles>().ToTable("user_user"); 
            modelBuilder.Entity<Titles>().Property(x => x.PrimaryTitle).HasColumnName("userid");
            modelBuilder.Entity<Titles>().Property(x => x.OriginalTitle).HasColumnName("firstname");
            modelBuilder.Entity<Titles>().Property(x => x.IsAdult).HasColumnName("lastname");
            modelBuilder.Entity<Titles>().Property(x => x.StartYear).HasColumnName("username");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("emailaddress");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("passwordsalt");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("passwordhash");
            modelBuilder.Entity<Titles>().ToTable("wi"); 
            modelBuilder.Entity<Titles>().Property(x => x.StartYear).HasColumnName("titleid");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("word");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("field");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("lexeme");
        }   
    }
}
