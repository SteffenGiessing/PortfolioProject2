/*
 * NameBookmark table DMO.
 */
using System;

namespace WebApplication.DMOs
{
    public class Name_Bookmark
    {
        public string Pid { get; set; }

        public int UserId { get; set; }

        public DateTime BookMarkTime { get; set; }
    }
}