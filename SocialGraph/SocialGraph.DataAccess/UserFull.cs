using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialGraph.DataAccess
{
    public class UserFull
    {
        public UserFull()
        {
            Hobbies = new List<string>();
            Friends = new List<System.Guid>();
        }
        public UserFull(user u, SocialEntities db)
        {
            IdUser = u.ID_User;
            FirstName = u.first_name;
            SecondName = u.second_name;
            MiddleName = u.middle_name;
            Birthday = u.birthday;
            Phone = u.Phone;
            Hobbies = new List<string>();
            Friends = new List<System.Guid>();

            var ThisUser = from tu in db.user
                           where tu.ID_User == u.ID_User
                           select tu;

            Friends = (from tu in ThisUser
                       select tu.user1).First().Union(
                      (from tu in ThisUser
                       select tu.user2).First()).Select<user, Guid>(user => user.ID_User);

            Gender = (from tu in ThisUser
                      join tg in db.gender on tu.ID_Gender equals tg.ID_Gender
                      select tg.name).First();

            Birthplace = (from tu in ThisUser
                          join tl in db.locality on tu.ID_Birthplace equals tl.ID_Locality
                          select tl.name).First();

            Residence = (from tu in ThisUser
                         join tl in db.locality on tu.ID_Residence equals tl.ID_Locality
                         select tl.name).First();

            Hobbies = (from tu in ThisUser
                       select tu.hobbie).First().Select<hobbie, String>(hobbie => hobbie.name);
        }
        public System.Guid IdUser { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public System.DateTime Birthday { get; set; }
        public string Birthplace { get; set; }
        public string Residence { get; set; }
        public string Phone { get; set; }
        public IEnumerable<string> Hobbies { get; set; }
        public IEnumerable<System.Guid> Friends { get; set; }
    }
}