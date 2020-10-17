using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bicyclefinder.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly BicycleFinderContext _context;

        public UsersController(BicycleFinderContext context)
        {
            _context = context;
        }

        private static readonly List<User> Users = new List<User>
        {
            new User {Id = 1, Name = "Anders B", Phone = "12345678", FirebaseUserId = "FAKE1"},
            new User {Id = 2, Name = "Peter", Phone = "87654321", FirebaseUserId = "FAKE2"}
        };

        //private static int _nextId = Users.Count + 1;

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            //return Users;
            return _context.Users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
            //return Users.FirstOrDefault(user => user.Id == id);
        }

        // GET api/<UsersController>/5
        [HttpGet("firebaseuserid/{id}")]
        public User GetByFirebaseUserId(string id)
        {
            return _context.Users.FirstOrDefault(user => user.FirebaseUserId == id);
            //return Users.FirstOrDefault(user => user.FirebaseUserId == id);
        }

        /*[HttpGet("test/test")]
        public string GoForIt()
        {
            return "test/test";
        }*/

        // POST api/<UsersController>
        [HttpPost]
        public User Post([FromBody] User value)
        {
            _context.Users.Add(value);
            _context.SaveChangesAsync();
            return value;
            /*if (Users.Exists(user => user.FirebaseUserId == value.FirebaseUserId))
            {
                return null;
            }
            value.Id = _nextId++;
            Users.Add(value);
            return value;*/
        }

        /*// PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/


    }
}
