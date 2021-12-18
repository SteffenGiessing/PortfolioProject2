using Microsoft.AspNetCore.Mvc;

namespace WebApplication.DTOs
{
    public class TokenChecker
    {
        [FromHeader] public string Authorization { get; set; }
    }
}