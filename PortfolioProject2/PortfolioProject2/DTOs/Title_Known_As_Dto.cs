﻿using System.Collections.Generic;

namespace PortfolioProject2.DTOs
{
    public class Title_Known_As_Dto
    {
        public string TitleId { get; set; }
        public int Ordering { get; set; }
        public string Title { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
        public string Types { get; set; }
        public string Attributes { get; set; }
        public bool IsOriginalTitle { get; set; }
    }
}