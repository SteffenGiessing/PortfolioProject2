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
        Title_Bookmark CreateTitleBookmark(int userId, string titleId);

        Title_Bookmark GetTitleBookmark(int userid, string titleid);

        IList <Title_Bookmark> GetTitleBookmarks(int userid);
        
        bool DeleteTitleBookmark (int userid, string titleid);
        //for actorbookmark
        Name_Bookmark GetNameBookmark(int userid, string titleid);
        IList<Name_Bookmark> GetNameBookmarks (int userid);
        Name_Bookmark CreateNameBookmark(int userid, string pid);
    }
}