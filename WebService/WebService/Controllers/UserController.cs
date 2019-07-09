using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebService;

namespace WebService.Controllers
{
    public class UserController : ApiController
    {
        private socialEntities db = new socialEntities();

        // GET: api/user
        public IEnumerable<UserSummary> Getuser()
        {
            DbSet<user> users = db.user;
            List<UserSummary> result = new List<UserSummary>();

            foreach (user u in users)
            {
                result.Add(new UserSummary(u, db));
            }

            return result;
        }

        // GET: api/user/5
        [ResponseType(typeof(UserFull))]
        public IHttpActionResult Getuser(Guid id)
        {
            user user = db.user.Find(id);
            UserFull result = new UserFull(user, db);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool userExists(Guid id)
        {
            return db.user.Count(e => e.ID_User == id) > 0;
        }
    }
}