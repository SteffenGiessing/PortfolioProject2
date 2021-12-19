/*
 * BookMark Interface.
 */

using System.Collections.Generic;
using WebApplication.DMOs;

namespace WebApplication.DataInterfaces
{
    public interface IBookMarkDataService
    {
        Title_Bookmark CreateTitleBookmark(int userid, string titleid);

        Title_Bookmark GetTitleBookmark(int userid, string titleid);

        IList<Title_Bookmark> GetTitleBookmarks(int userid);

        bool DeleteTitleBookmark(int userid, string titleid);

        Name_Bookmark GetNameBookmark(int userid, string titleid);
        IList<Name_Bookmark> GetNameBookmarks(int userid);
        Name_Bookmark CreateNameBookmark(int userid, string pid);
    }
}