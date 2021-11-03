using System;
using Microsoft.EntityFrameworkCore;
using System;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Models
{
    public class DatabaseConnection : DbContext
    {
        public DbSet<Episodes> Episodes { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Omdb_Data> Omdb_Data { get; set; }
        public DbSet<Person_In_Title> Person_In_Title { get; set; }
        public DbSet<Person_Info> Person_Info { get; set; }
        public DbSet<Person_Known_For> Person_Known_For { get; set; }
        public DbSet<Person_Profession> Person_Profession { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<Title_Known_As> Title_Known_As { get; set; }
        public DbSet<Titles> Titles { get; set; }
        public DbSet<User_BookMarks> User_BookMarks { get; set; }
        public DbSet<User_Comments> User_Comments { get; set; }
        public DbSet<User_History> User_History { get; set; }
        public DbSet<User_Ratings> User_Ratings { get; set; }
        public DbSet<User_User> User_User { get; set; }
        public DbSet<Wi> Wi { get; set; }


        private readonly string connectionString =
            "host=rawdata.ruc.dk;port=5432;database=raw8;username=raw8;password=utuBOPUw";

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


            modelBuilder.Entity<Episodes>().ToTable("episodes");
            modelBuilder.Entity<Episodes>().Property(x => x.EpisodeId).HasColumnName("episodeid");
            modelBuilder.Entity<Episodes>().Property(x => x.SeriesId).HasColumnName("seriesid");
            modelBuilder.Entity<Episodes>().Property(x => x.SeasonNumber).HasColumnName("seasonnumber");
            modelBuilder.Entity<Episodes>().Property(x => x.EpisodeNumber).HasColumnName("episodenumber");


            modelBuilder.Entity<Genre>().ToTable("genre");
            modelBuilder.Entity<Genre>().Property(x => x.TitleId).HasColumnName("titleid");
            modelBuilder.Entity<Genre>().Property(x => x.Genres).HasColumnName("genres");
            

            modelBuilder.Entity<Omdb_Data>().ToTable("omdb_Data");
            modelBuilder.Entity<Omdb_Data>().Property(x => x.TitleId).HasColumnName("titleid");
            modelBuilder.Entity<Omdb_Data>().Property(x => x.Poster).HasColumnName("poster");
            modelBuilder.Entity<Omdb_Data>().Property(x => x.Awards).HasColumnName("awards");
            modelBuilder.Entity<Omdb_Data>().Property(x => x.Plot).HasColumnName("plot");


            modelBuilder.Entity<Person_In_Title>().ToTable("person_in_title");
            modelBuilder.Entity<Person_In_Title>().Property(x => x.TitleId).HasColumnName("titleid");
            modelBuilder.Entity<Person_In_Title>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<Person_In_Title>().Property(x => x.Pid).HasColumnName("pid");
            modelBuilder.Entity<Person_In_Title>().Property(x => x.Role).HasColumnName("role");
            modelBuilder.Entity<Person_In_Title>().Property(x => x.Job).HasColumnName("job");
            modelBuilder.Entity<Person_In_Title>().Property(x => x.CharName).HasColumnName("charname");


            modelBuilder.Entity<Person_Info>().ToTable("person_info");
            modelBuilder.Entity<Person_Info>().Property(x => x.Pid).HasColumnName("pid");
            modelBuilder.Entity<Person_Info>().Property(x => x.PrimaryName).HasColumnName("primaryname");
            modelBuilder.Entity<Person_Info>().Property(x => x.BirthYear).HasColumnName("birthyear");
            modelBuilder.Entity<Person_Info>().Property(x => x.DeathYear).HasColumnName("deathyear");


            modelBuilder.Entity<Person_Known_For>().ToTable("person_known_for");
            modelBuilder.Entity<Person_Known_For>().Property(x => x.Pid).HasColumnName("pid");
            modelBuilder.Entity<Person_Known_For>().Property(x => x.KnownForTitle).HasColumnName("knownfortitle");


            modelBuilder.Entity<Person_Profession>().ToTable("person_profession");
            modelBuilder.Entity<Person_Profession>().Property(x => x.Pid).HasColumnName("pid");
            modelBuilder.Entity<Person_Profession>().Property(x => x.Profession).HasColumnName("profession");


            modelBuilder.Entity<Ratings>().ToTable("ratings");
            modelBuilder.Entity<Ratings>().Property(x => x.TitleId).HasColumnName("titleid");
            modelBuilder.Entity<Ratings>().Property(x => x.AverageRating).HasColumnName("averagerating");
            modelBuilder.Entity<Ratings>().Property(x => x.NumVotes).HasColumnName("numvotes");


            modelBuilder.Entity<Title_Known_As>().ToTable("title_known_as");
            modelBuilder.Entity<Title_Known_As>().Property(x => x.TitleId).HasColumnName("titleid");
            modelBuilder.Entity<Title_Known_As>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<Title_Known_As>().Property(x => x.Title).HasColumnName("title");
            modelBuilder.Entity<Title_Known_As>().Property(x => x.Region).HasColumnName("region");
            modelBuilder.Entity<Title_Known_As>().Property(x => x.Language).HasColumnName("language");
            modelBuilder.Entity<Title_Known_As>().Property(x => x.Types).HasColumnName("types");
            modelBuilder.Entity<Title_Known_As>().Property(x => x.Attributes).HasColumnName("attributes");
            modelBuilder.Entity<Title_Known_As>().Property(x => x.IsOriginalTitle).HasColumnName("isoriginaltitle");


            modelBuilder.Entity<Titles>().ToTable("titles");
            modelBuilder.Entity<Titles>().Property(x => x.TitleId).HasColumnName("titleid");
            modelBuilder.Entity<Titles>().Property(x => x.TitleType).HasColumnName("titletype");
            modelBuilder.Entity<Titles>().Property(x => x.PrimaryTitle).HasColumnName("primarytitle");
            modelBuilder.Entity<Titles>().Property(x => x.OriginalTitle).HasColumnName("originaltitle");
            modelBuilder.Entity<Titles>().Property(x => x.IsAdult).HasColumnName("isadult");
            modelBuilder.Entity<Titles>().Property(x => x.StartYear).HasColumnName("startyear");
            modelBuilder.Entity<Titles>().Property(x => x.EndYear).HasColumnName("endyear");
            modelBuilder.Entity<Titles>().Property(x => x.RunTime).HasColumnName("runtime");
            modelBuilder.Entity<Titles>().Property(x => x.Genres).HasColumnName("genres");


            modelBuilder.Entity<User_BookMarks>().ToTable("user_bookmarks");
            modelBuilder.Entity<User_BookMarks>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<User_BookMarks>().Property(x => x.TitleId).HasColumnName("titleid");


            modelBuilder.Entity<User_Comments>().ToTable("user_comments");
            modelBuilder.Entity<User_Comments>().Property(x => x.CommentText).HasColumnName("commenttext");
            modelBuilder.Entity<User_Comments>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<User_Comments>().Property(x => x.TitleId).HasColumnName("titleid");
            modelBuilder.Entity<User_Comments>().Property(x => x.CommentTime).HasColumnName("commenttime");
            modelBuilder.Entity<User_Comments>().Property(x => x.CommentId).HasColumnName("commentid");


            modelBuilder.Entity<User_History>().ToTable("user_history");
            modelBuilder.Entity<User_History>().Property(x => x.SearchId).HasColumnName("searchid");
            modelBuilder.Entity<User_History>().Property(x => x.SearchText).HasColumnName("searchtext");
            modelBuilder.Entity<User_History>().Property(x => x.UserId).HasColumnName("userid");


            modelBuilder.Entity<User_Ratings>().ToTable("user_ratings");
            modelBuilder.Entity<User_Ratings>().Property(x => x.TitleId).HasColumnName("titleid");
            modelBuilder.Entity<User_Ratings>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<User_Ratings>().Property(x => x.RateNumber).HasColumnName("ratenumber");


            modelBuilder.Entity<User_User>().ToTable("user_user");
            modelBuilder.Entity<User_User>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<User_User>().Property(x => x.FirstName).HasColumnName("firstname");
            modelBuilder.Entity<User_User>().Property(x => x.LastName).HasColumnName("lastname");
            modelBuilder.Entity<User_User>().Property(x => x.UserName).HasColumnName("username");
            modelBuilder.Entity<User_User>().Property(x => x.EmailAddress).HasColumnName("emailaddress");
            modelBuilder.Entity<User_User>().Property(x => x.PasswordSalt).HasColumnName("passwordsalt");
            modelBuilder.Entity<User_User>().Property(x => x.PasswordHash).HasColumnName("passwordhash");


            modelBuilder.Entity<Wi>().ToTable("wi");
            modelBuilder.Entity<Wi>().Property(x => x.TitleId).HasColumnName("titleid");
            modelBuilder.Entity<Wi>().Property(x => x.Word).HasColumnName("word");
            modelBuilder.Entity<Wi>().Property(x => x.Field).HasColumnName("field");
            modelBuilder.Entity<Wi>().Property(x => x.Lexeme).HasColumnName("lexeme");
        }
    }
}