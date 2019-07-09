using System;
using System.Linq;
using System.Collections.Generic;

namespace WebService
{
    public class UserSummary
    {
        public UserSummary(user u, socialEntities db)
        {
            ID_User = u.ID_User;
            first_name = u.first_name;
            second_name = u.second_name;
            friends = new List<System.Guid>();

            foreach (user ur in u.user1)
                friends.Add(ur.ID_User);

            foreach (user ur in u.user2)
                friends.Add(ur.ID_User);

            var thisUser = from ur in db.user
                           where ur.ID_User == u.ID_User
                           select ur;

            var query = from ur in thisUser
                        join g in db.gender on ur.ID_Gender equals g.ID_Gender
                        select g.name;

            gender = query.First();
        }
        public System.Guid ID_User { get; set; }
        public string second_name { get; set; }
        public string first_name { get; set; }
        public string gender { get; set; }
        public ICollection<System.Guid> friends { get; set; }
    }
}