using System;
using Microsoft.EntityFrameworkCore;
using PortfolioProject2.Models.DMOs;


namespace PortfolioProject2.Models
{
    public class DatabaseConnection : DbContext
    {
        public DbSet<Titles> Titles { get; set; }
        public DbSet<Episodes> Episodes { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Omdb_Data> Omdb_Data { get; set; }
        public DbSet<Person_In_Title> Person_In_Title { get; set; }
        public DbSet<Person_Info> Person_Info { get; set; }
        public DbSet<Person_Known_For> Person_Known_For { get; set; }
        public DbSet<Person_Profession> Person_Profession { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<Title_Known_As> Title_Known_As { get; set; }
      
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

            // Episodes
            modelBuilder.Entity<Episodes>(entity =>
            {
                // Points to Database Episodes
                entity.ToTable("episodes");
<<<<<<< main
                
                // Sets Primary Key
                entity.HasKey(x => x.EpisodeId).HasName("episodeid");
                
                // Sets Foreign Key
                entity.HasOne(x => x.Titles).WithOne(d => d.Episodes)
                    .HasForeignKey<Episodes>(x => x.SeriesId);
                
=======

>>>>>>> New thing
                // Sets properties
                entity.Property(x => x.EpisodeId).HasColumnName("episodeid");
                entity.Property(x => x.SeriesId).HasColumnName("seriesid");
                entity.Property(x => x.SeasonNumber).HasColumnName("seasonnumber");
                entity.Property(x => x.EpisodeNumber).HasColumnName("episodenumber");
            });
            
            
            // Genre
            modelBuilder.Entity<Genre>(entity =>
            {
                // Points to Database Genre
                entity.ToTable("genre");
                
<<<<<<< main
                //Sets Primary Key -> Composite
                entity.HasKey(x => new { titleid = x.TitleId, genres = x.Genres});
                
                //Sets Foreign Key
                entity.HasOne(x => x.Titles).WithOne(d => d.Genre)
                    .HasForeignKey<Genre>(x => x.TitleId);
                
=======
>>>>>>> New thing
                //Sets Properties
                entity.Property(x => x.TitleId).HasColumnName("titleid");
                entity.Property(x => x.Genres).HasColumnName("genres");
            });

            
            // Omdb_Data
            modelBuilder.Entity<Omdb_Data>(entity =>
            {
                // Points to Database Omdb_Data
                entity.ToTable("omdb_Data");
<<<<<<< main
                
                // Sets Primary Key
                entity.HasKey(x => x.TitleId).HasName("titleid");
                
                // Sets Foreign Key
                entity.HasOne(x => x.Titles).WithOne(d => d.Omdb_Data)
                    .HasForeignKey<Omdb_Data>(x => x.TitleId);
                
=======

>>>>>>> New thing
                // Sets properties
                entity.Property(x => x.TitleId).HasColumnName("titleid");
                entity.Property(x => x.Poster).HasColumnName("poster");
                entity.Property(x => x.Awards).HasColumnName("awards");
                entity.Property(x => x.Plot).HasColumnName("plot");
            });

            
            // Person_In_Title
            modelBuilder.Entity<Person_In_Title>(entity =>
            {
                // Points to Database Person_In_Title
                entity.ToTable("person_in_title");
                
                // Sets properties
                entity.Property(x => x.TitleId).HasColumnName("titleid");
                entity.Property(x => x.Ordering).HasColumnName("ordering");
                entity.Property(x => x.Pid).HasColumnName("pid");
                entity.Property(x => x.Role).HasColumnName("role");
                entity.Property(x => x.Job).HasColumnName("job");
                entity.Property(x => x.CharName).HasColumnName("charname");
            });
            

            // Person_Info
            modelBuilder.Entity<Person_Info>(entity =>
            {
                // Points to Database Person_Info
                entity.ToTable("person_info");
                
<<<<<<< main
                // Sets Primary Key
                entity.HasKey(x => x.Pid).HasName("pid");
                
                // Sets Foreign Key
              
                
=======
>>>>>>> New thing
                // Sets properties
                entity.Property(x => x.Pid).HasColumnName("pid");
                entity.Property(x => x.PrimaryName).HasColumnName("primaryname");
                entity.Property(x => x.BirthYear).HasColumnName("birthyear");
                entity.Property(x => x.DeathYear).HasColumnName("deathyear");
            });
            
            
            // Person_Known_For
            modelBuilder.Entity<Person_Known_For>(entity =>
            {
                // Points to Database person_known_for
                entity.ToTable("person_known_for");
<<<<<<< main
                
                // Sets Primary Key -> Composite key
                entity.HasKey(x => new {pid = x.Pid, knownfortitle = x.KnownForTitle});
                
                // Sets Foreign Key
              
                
=======

>>>>>>> New thing
                // Sets properties
                entity.Property(x => x.Pid).HasColumnName("pid");
                entity.Property(x => x.KnownForTitle).HasColumnName("knownfortitle");
            });
            

            // Person_Profession
            modelBuilder.Entity<Person_Profession>(entity =>
            {
                // Points to Database person_profession
                entity.ToTable("person_profession");
                
<<<<<<< main
                // Sets Primary Key -> Composite Key
                entity.HasKey(x => new {pid = x.Pid, profession = x.Profession});
                
                // Sets Foreign Key
              
                
=======
>>>>>>> New thing
                // Sets properties
                entity.Property(x => x.Pid).HasColumnName("pid");
                entity.Property(x => x.Profession).HasColumnName("profession");
            });
            
            
            // Ratings
            modelBuilder.Entity<Ratings>(entity =>
            {
                // Points to Database ratings
                entity.ToTable("ratings");
                
<<<<<<< main
                // Sets Primary Key
                entity.HasKey(x => x.TitleId).HasName("titleid");
                
                // Sets Foreign Key
              
                
=======
>>>>>>> New thing
                // Sets properties
                entity.Property(x => x.TitleId).HasColumnName("titleid");
                entity.Property(x => x.AverageRating).HasColumnName("averagerating");
                entity.Property(x => x.NumVotes).HasColumnName("numvotes");
            });
          
            
            // Title_Known_As
            modelBuilder.Entity<Title_Known_As>(entity =>
            {
                // Points to Database title_known_as
                entity.ToTable("title_known_as");
<<<<<<< main
                
                // Sets Primary Key -> Composite Key
                entity.HasKey(x => new { titleid = x.TitleId, ordering = x.Ordering});
                
                // Sets Foreign Key
                entity.HasOne(x => x.Titles).WithOne(d => d.Title_Known_As)
                    .HasForeignKey<Title_Known_As>(x => x.TitleId);
                
=======

>>>>>>> New thing
                // Sets properties
                entity.Property(x => x.TitleId).HasColumnName("titleid");
                entity.Property(x => x.Ordering).HasColumnName("ordering");
                entity.Property(x => x.Title).HasColumnName("title");
                entity.Property(x => x.Region).HasColumnName("region");
                entity.Property(x => x.Language).HasColumnName("language");
                entity.Property(x => x.Types).HasColumnName("types");
                entity.Property(x => x.Attributes).HasColumnName("attributes");
                entity.Property(x => x.IsOriginalTitle).HasColumnName("isoriginaltitle");
            });

            
            // Titles
            modelBuilder.Entity<Titles>(entity =>
            {
                // Points to Database titles
                entity.ToTable("titles");
<<<<<<< main
                
                // Sets Primary Key
                entity.HasKey(x => x.TitleId).HasName("titleid");
                
                // Sets Foreign Key
              
                
=======

>>>>>>> New thing
                // Sets properties
                entity.Property(x => x.TitleId).HasColumnName("titleid");
                entity.Property(x => x.TitleType).HasColumnName("titletype");
                entity.Property(x => x.PrimaryTitle).HasColumnName("primarytitle");
                entity.Property(x => x.OriginalTitle).HasColumnName("originaltitle");
                entity.Property(x => x.IsAdult).HasColumnName("isadult");
                entity.Property(x => x.StartYear).HasColumnName("startyear");
                entity.Property(x => x.EndYear).HasColumnName("endyear");
                entity.Property(x => x.RunTime).HasColumnName("runtime");
                entity.Property(x => x.Genres).HasColumnName("genres");

            });
        
            
            // User_BookMarks
            modelBuilder.Entity<User_BookMarks>(entity =>
            {
                // Points to Database user_bookmarks
                entity.ToTable("user_bookmarks");
<<<<<<< main
                
                // Sets Primary Key
                entity.HasKey(x => x.BookMarkId).HasName("bookmarkid");
                
                // Sets Foreign Key
              
                
=======

>>>>>>> New thing
                // Sets properties
                entity.Property(x => x.BookMarkId).HasColumnName("bookmarkid");
                entity.Property(x => x.UserId).HasColumnName("userid");
                entity.Property(x => x.TitleId).HasColumnName("titleid");
            });
            
            
            // User_Comments
            modelBuilder.Entity<User_Comments>(entity =>
            {
                // Points to Database user_comments
                entity.ToTable("user_comments");
                
<<<<<<< main
                // Sets Primary Key
                entity.HasKey(x => x.CommentId).HasName("commentid");
                
                // Sets Foreign Key
              
                
=======
>>>>>>> New thing
                // Sets properties
                entity.Property(x => x.CommentText).HasColumnName("commenttext");
                entity.Property(x => x.UserId).HasColumnName("userid");
                entity.Property(x => x.TitleId).HasColumnName("titleid");
                entity.Property(x => x.CommentTime).HasColumnName("commenttime");
                entity.Property(x => x.CommentId).HasColumnName("commentid");

            });
          

            // User_History
            modelBuilder.Entity<User_History>(entity =>
            {
                // Points to Database user_history
                entity.ToTable("user_history");
<<<<<<< main
                
                // Sets Primary Key
                entity.HasKey(x => x.SearchId).HasName("searchid");
                
                // Sets Foreign Key
              
                
=======

>>>>>>> New thing
                // Sets properties
                entity.Property(x => x.SearchId).HasColumnName("searchid");
                entity.Property(x => x.SearchText).HasColumnName("searchtext");
                entity.Property(x => x.UserId).HasColumnName("userid");
            });
           

            // User_Ratings
            modelBuilder.Entity<User_Ratings>(entity =>
            {
                // Points to Database user_ratings
                entity.ToTable("user_ratings");
<<<<<<< main
                
                // Sets Primary Key -> Composite Key
                entity.HasKey(x => new { titleid = x.TitleId, userid = x.UserId});
                
                // Sets Foreign Key
              
                
=======

>>>>>>> New thing
                // Sets properties
                entity.Property(x => x.TitleId).HasColumnName("titleid");
                entity.Property(x => x.UserId).HasColumnName("userid");
                entity.Property(x => x.RateNumber).HasColumnName("ratenumber");
            });
            

            // User_User
            modelBuilder.Entity<User_User>(entity =>
            {
                // Points to Database user_user
                entity.ToTable("user_user");
<<<<<<< main
                
                // Sets Primary Key
                entity.HasKey(x => x.UserId).HasName("userid");
                
                // Sets Foreign Key
              
                
=======

>>>>>>> New thing
                // Sets properties
                entity.Property(x => x.UserId).HasColumnName("userid");
                entity.Property(x => x.FirstName).HasColumnName("firstname");
                entity.Property(x => x.LastName).HasColumnName("lastname");
                entity.Property(x => x.UserName).HasColumnName("username");
                entity.Property(x => x.EmailAddress).HasColumnName("emailaddress");
                entity.Property(x => x.PasswordSalt).HasColumnName("passwordsalt");
                entity.Property(x => x.PasswordHash).HasColumnName("passwordhash");
            });
           

            // Wi
            modelBuilder.Entity<Wi>(entity =>
            {
                // Points to Database wi
                entity.ToTable("wi");
<<<<<<< main
                
                // Sets Primary Key -> Composite Key
                entity.HasKey(x => new { titleid = x.TitleId, word = x.Word, field = x.Lexeme});
                
                // Sets Foreign Key
              
                
=======

>>>>>>> New thing
                // Sets properties
                entity.Property(x => x.TitleId).HasColumnName("titleid");
                entity.Property(x => x.Word).HasColumnName("word");
                entity.Property(x => x.Field).HasColumnName("field");
                entity.Property(x => x.Lexeme).HasColumnName("lexeme");
            });
        }
    }
}