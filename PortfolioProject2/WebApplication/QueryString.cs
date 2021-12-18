﻿namespace WebApplication
{
    public class QueryString
    {
        public const int MaxPageSize = 25;
        private int _pageSize = 12;

        public int Page { get; set; } = 0;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public string OrderBy { get; set; }
    }
}