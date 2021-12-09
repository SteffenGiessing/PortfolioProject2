﻿using System.ComponentModel.DataAnnotations;

namespace PortfolioProject2.Models.DMOs
{
    public class TitleSearch
    {
        public string PrimaryTitle { get; set; }
        
        public string TitleId { get; set; }
        
        public string Poster { get; set; }
        public string StartYear { get; set; }
    }
}