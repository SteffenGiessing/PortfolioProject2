using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioProject2.Models.DMOs;
using WebApplication.DMOs;

namespace WebApplication.DataInterfaces
{
    public interface IBookMarkDataService
    {
        //for titlebookmark
        Title_Bookmark CreateTitleBookmark(string userid, string titleid);

        Title_Bookmark GetTitleBookmark(string userid, string titleid);

        IList <Title_Bookmark> GetTitleBookmarks(string userid);
        
        bool DeleteTitleBookmark (string userid, string titleid);
        //for actorbookmark
        Name_Bookmark GetNameBookmark(string userid, string titleid);
        IList<Name_Bookmark> GetNameBookmarks (string userid);
        Name_Bookmark CreateNameBookmark(string userid, string pid);
    }
}