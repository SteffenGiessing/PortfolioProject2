/*
 * Title_bookmark table DMO.
 */
using System;

namespace WebApplication.DMOs
{
    public class Title_Bookmark
    {
        public int UserId { get; set; }
        public string TitleId { get; set; }
        public DateTime BookMarkTime { get; set; }
    }
}