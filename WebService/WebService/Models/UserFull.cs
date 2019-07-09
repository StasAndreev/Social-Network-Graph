using System;
using System.Collections.Generic;
using System.Linq;
using WebService;

namespace WebService
{
    public class UserFull
    {
        public UserFull(user u, socialEntities db)
        {
            ID_User = u.ID_User;
            first_name = u.first_name;
            second_name = u.second_name;
            middle_name = u.middle_name;
            birthday = u.birthday;
            phone = u.Phone;
            friends = new List<System.Guid>();
            hobbies = new List<string>();

            foreach (user ur in u.user1)
                friends.Add(ur.ID_User);

            foreach (user ur in u.user2)
                friends.Add(ur.ID_User);

            foreach (hobbie h in u.hobbie)
                hobbies.Add(h.name);

            var thisUser = from ur in db.user
                           where ur.ID_User == u.ID_User
                           select ur;

            var queryGender = from ur in thisUser
                        join g in db.gender on ur.ID_Gender equals g.ID_Gender
                        select g.name;

            var queryBirthplace = from ur in thisUser
                                  join l in db.locality on ur.ID_Birthplace equals l.ID_Locality
                                  select l.name;

            var queryResidence = from ur in thisUser
                                 join l in db.locality on ur.ID_Residence equals l.ID_Locality
                                 select l.name;

            gender = queryGender.First();
            birthplace = queryBirthplace.First();
            residence = queryResidence.First();
        }
        public System.Guid ID_User { get; set; }
        public string second_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string gender { get; set; }
        public System.DateTime birthday { get; set; }
        public string birthplace { get; set; }
        public string residence { get; set; }
        public string phone { get; set; }
        public ICollection<string> hobbies { get; set; }
        public ICollection<System.Guid> friends { get; set; }
    }
}