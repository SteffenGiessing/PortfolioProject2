using System;
using Microsoft.EntityFrameworkCore;
using System;
namespace PortfolioProject2.Models
{
    public class DatabaseConnection : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseNpgsql("host=localhost;db=imdb_new;uid=postgres;pwd=");
            
            
            Console.WriteLine("Hallo");
        }
    }
}
