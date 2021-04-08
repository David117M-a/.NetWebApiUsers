using ApiWebUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebServices.Models;
using WebServices.Services;

namespace ApiWebUsers.Controllers
{
    [Route("api/users")]
    [EnableCors("*", "*", "*")]
    public class UsersController : ApiController
    {
        private UsersManagerEntities entities = new UsersManagerEntities();

        public IHttpActionResult Get()
        {
            try
            {
                List<Users> users = entities.Users.ToList();
                List<UserSM> userSM = users.Select(p => new UserSM
                {
                    id = p.id,
                    Username = p.Username,
                    Pass = p.Pass
                }).ToList();

                return Ok(userSM);
            }
            catch (Exception e)
            {
                string error = e.Message;
                return BadRequest("Error: " + error);            }
        }

        [Route("api/users/create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] UserSM userSM)
        {
            try
            {
                UserServices service = new UserServices();

                Users user = new Users();
                user.Username = userSM.Username;
                user.Pass = userSM.Pass;

                service.Create(user);
                return Ok(userSM);
            }
            catch (Exception e)
            {
                string error = e.Message;
                return BadRequest("Error: " + error);
            }
        }

        [Route("api/users/delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                UserServices service = new UserServices();
                service.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                string error = e.Message;
                return BadRequest("Error: " + error);
            }
        }
    }
}
