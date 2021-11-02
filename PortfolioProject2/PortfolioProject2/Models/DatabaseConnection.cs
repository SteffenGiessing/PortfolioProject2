using System;
using Microsoft.EntityFrameworkCore;
using System;
namespace PortfolioProject2.Models
{
    public class DatabaseConnection : DbContext
    {
        private readonly string connectionString = "host=rawdata.ruc.dk;port=5432;database=raw8;username=raw8;password=utuBOPUw";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseNpgsql(connectionString);
            
            
            Console.WriteLine("Hallo");
        }
    }
}
