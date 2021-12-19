/*
 * Person_info table DMO.
 */
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.DMOs
{
    [Table("actor")]
    public class Person_Info
    {
        public string Pid { get; set; }

        public string PrimaryName { get; set; }

        public string? BirthYear { get; set; }

        public string? DeathYear { get; set; }
    }
}