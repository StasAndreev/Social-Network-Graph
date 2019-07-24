using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SocialGraph.DataAccess
{
    public class DataBase
    {
        public IEnumerable<UserSummary> GetUserList()
        {
            List<UserSummary> Result = new List<UserSummary>();

            using (SocialEntities DB = new SocialEntities())
            {
                DbSet<user> Users = DB.user;
                foreach (user u in Users)
                {
                    Result.Add(new UserSummary(u, DB));
                }
            }

            return Result;
        }

        public bool HasUser(Guid ID)
        {
            using (SocialEntities DB = new SocialEntities())
            {
                return DB.user.Find(ID) != null;
            }
        }

        public UserFull GetUserFull(Guid ID)
        {
            using (SocialEntities DB = new SocialEntities())
            {
                user User = DB.user.Find(ID);
                return new UserFull(User, DB);
            }
        }
    }
}