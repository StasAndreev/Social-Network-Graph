using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SocialGraph.DataAccess;

namespace WebService.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/user
        public IEnumerable<UserSummary> GetUser()
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

        // GET: api/user/5
        [ResponseType(typeof(UserFull))]
        public IHttpActionResult GetUser(Guid id)
        {
            UserFull Result;

            using (SocialEntities DB = new SocialEntities())
            {
                user User = DB.user.Find(id);
                if (User == null)
                {
                    return NotFound();
                }
                Result = new UserFull(User, DB);
            }

            return Ok(Result);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}