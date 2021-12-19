using System;
using System.Collections.Generic;
using WebApplication.DataInterfaces;
using WebApplication.DMOs;

namespace WebApplication.DataServices
{
    public class BookMarkDataService : IBookMarkDataService
    {
        public DatabaseConnection.DatabaseConnection ctx { get; set; }

        public Title_Bookmark GetTitleBookmark(int userid, string titleid)
        {
            return ctx.Title_Bookmark.Find(userid, titleid);
        }

        //titlebookmarks
        public IList<Title_Bookmark> GetTitleBookmarks(int userid)
        {
            IList<Title_Bookmark> result = new List<Title_Bookmark>();
            using var ctx = new DatabaseConnection.DatabaseConnection();

            foreach (var bk in ctx.Title_Bookmark)
            {
                if (bk.UserId == userid)
                {
                    result.Add(bk);
                }
            }

            return result;
        }

        public Title_Bookmark CreateTitleBookmark(int userid, string titleid)
        {
            //need a way to validate user
            using var ctx = new DatabaseConnection.DatabaseConnection();
            var result = new Title_Bookmark
            {
                UserId = userid,
                TitleId = titleid,
                BookMarkTime = DateTime.Now
            };
            ctx.Title_Bookmark.Add(result);
            int a = ctx.SaveChanges();
            if (a == 0)
            {
                return null;
            }

            return result;
        }

        public bool DeleteTitleBookmark(int userid, string titleid)
        {
            var titleBookmark = ctx.Title_Bookmark.Find(userid, titleid);
            if (titleBookmark == null)
            {
                return false;
            }

            ctx.Title_Bookmark.Remove(titleBookmark);
            ctx.SaveChanges();
            return true;
        }

        //actorbookmarks------------------------------------------------------
        public Name_Bookmark GetNameBookmark(int userid, string pid)
        {
            return ctx.Name_Bookmark.Find(userid, pid);
        }

        public IList<Name_Bookmark> GetNameBookmarks(int userid)
        {
            IList<Name_Bookmark> result = new List<Name_Bookmark>();
            using var ctx = new DatabaseConnection.DatabaseConnection();

            foreach (var bk in ctx.Name_Bookmark)
            {
                if (bk.UserId == userid)
                {
                    result.Add(bk);
                }
            }

            return result;
        }

        public Name_Bookmark CreateNameBookmark(int userid, string pid)
        {
            using var ctx = new DatabaseConnection.DatabaseConnection();
            var result = new Name_Bookmark()
            {
                UserId = userid,
                Pid = pid,
                BookMarkTime = DateTime.Now
            };
            ctx.Name_Bookmark.Add(result);
            ctx.SaveChanges();
            return result;
        }
    }
}