using System.Collections.Generic;
using PortfolioProject2.Models.DMOs;

namespace WebApplication.DataInterfaces
{
    public interface IBookMarkDataService
    {
        //for titlebookmark
        Title_Bookmark CreateTitleBookmark(int userid, string titleid);

        Title_Bookmark GetTitleBookmark(int userid, string titleid);

        IList<Title_Bookmark> GetTitleBookmarks(int userid);

        bool DeleteTitleBookmark(int userid, string titleid);

        //for actorbookmark
        Name_Bookmark GetNameBookmark(int userid, string titleid);
        IList<Name_Bookmark> GetNameBookmarks(int userid);
        Name_Bookmark CreateNameBookmark(int userid, string pid);
    }
}