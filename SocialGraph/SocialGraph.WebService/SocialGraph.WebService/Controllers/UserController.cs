using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Http.Description;
using SocialGraph.DataAccess;

namespace WebService.Controllers
{
    public class UserController : ApiController
    {
        private DataBase DB = new DataBase();

        // GET: api/user
        public IEnumerable<UserSummary> GetUser()
        {
            return DB.GetUserList();
        }

        // GET: api/user/5
        [ResponseType(typeof(UserFull))]
        public IHttpActionResult GetUser(Guid ID)
        {
            if (!DB.HasUser(ID))
            {
                return NotFound();
            }

            return Ok(DB.GetUserFull(ID));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}