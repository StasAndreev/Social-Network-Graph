using System;
using System.Linq;
using System.Collections.Generic;

namespace SocialGraph.DataAccess
{
    public class UserSummary
    {
        public UserSummary(user u, SocialEntities db)
        {
            IdUser = u.ID_User;
            Friends = new List<System.Guid>();

            var ThisUser = from tu in db.user
                           where tu.ID_User == u.ID_User
                           select tu;

            Friends = (from tu in ThisUser
                       select tu.user1).First().Union(
                      (from tu in ThisUser
                       select tu.user2).First()).Select<user, Guid>(user => user.ID_User);
        }
        public System.Guid IdUser { get; set; }

        public IEnumerable<System.Guid> Friends { get; set; }
    }
}