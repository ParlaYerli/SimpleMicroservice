using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Database.Context;
using UserService.Database.Entities;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserContext _db;
        public UserController()
        {
            _db = new UserContext();
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _db.Users.ToList();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return _db.Users.Find(id);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created,user);
            }
            catch (Exception ex) 
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
           
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
