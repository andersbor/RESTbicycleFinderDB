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
    public class BicyclesController : ControllerBase
    {
        private readonly BicycleFinderContext _context;

        public BicyclesController(BicycleFinderContext context)
        {
            _context = context;
        }

        /*private static readonly List<Bicycle> Bicycles = new List<Bicycle>
        {
            new Bicycle
            {
                Id = 1, Brand = "Kildemoes", Colors = "Silver black", FrameNumber = "1WE31", KindOfBicycle = "Man", MissingFound = "missing", Place = "Roskilde", Date = "20200913", UserId = 1, FirebaseUserId = "6rdeJoM8WpdP466SIntDAwXFXPg2", Name = "Anders B", Phone = "12345678"
            },
            new Bicycle {Id=2, Brand = "Raleigh", Colors="Orange", FrameNumber = "2WD3S", KindOfBicycle = "Woman", MissingFound = "found", Place = "Roskilde", Date = "20200913", UserId = 2, FirebaseUserId = "6rdeJoM8WpdP466SIntDAwXFXPg2", Name = "Anders B", Phone = "12345678"},
            new Bicycle {Id=3, Brand = "Raleigh", Colors="Orange", FrameNumber = "12ERR", KindOfBicycle = "Child", MissingFound = "found", Place = "Ringsted", Date = "20200913", UserId = 1, FirebaseUserId = "6rdeJoM8WpdP466SIntDAwXFXPg2", Name = "Anders B", Phone = "12345678"},
            new Bicycle {Id=4, Brand = "Chartour", Colors="Pink", FrameNumber = "2WD3S", KindOfBicycle = "Woman", MissingFound = "missing", Place = "Roskilde", Date = "20200913", UserId = 2, FirebaseUserId = "6rdeJoM8WpdP466SIntDAwXFXPg2", Name = "Anders B", Phone = "12345678"}
        };

        private static int _nextId = Bicycles.Count + 1;
        */

        // GET: api/<BicyclesController>
        [HttpGet]
        public IEnumerable<Bicycle> GetAll()
        {
            return _context.Bicycles;
        }

        [HttpGet("{missingFound}")]
        public IEnumerable<Bicycle> GetMissingOrFound(string missingFound)
        {
            return _context.Bicycles.Where(bicycle =>
                bicycle.MissingFound != null &&
                bicycle.MissingFound.Equals(missingFound, StringComparison.OrdinalIgnoreCase));
        }

        /*/ GET: api/<BicyclesController>
        [HttpGet("lost")]
        public IEnumerable<Bicycle> GetAllMissing()
        {
            return Bicycles.FindAll(bicycle =>
                bicycle.MissingFound.Equals("lost", StringComparison.OrdinalIgnoreCase));
        }
        
        // GET: api/<BicyclesController>
        [HttpGet("found")]
        public IEnumerable<Bicycle> GetAllFound()
        {
            return Bicycles.FindAll(bicycle =>
                bicycle.MissingFound.Equals("found", StringComparison.OrdinalIgnoreCase));
        }*/


        // GET api/<BicyclesController>/5
        [HttpGet("id/{id}")]
        public Bicycle Get(int id)
        {
            return _context.Bicycles.FirstOrDefault(bicycle => bicycle.Id == id);
        }

        [HttpGet("firebaseUserId/{firebaseUserId}")]
        public IEnumerable<Bicycle> GetByFirebaseUserId(string firebaseUserId)
        {
            return _context.Bicycles.Where(bicycle =>
                bicycle.FirebaseUserId == firebaseUserId);
        }


        // POST api/<BicyclesController>
        [HttpPost]
        public Bicycle Post([FromBody] Bicycle value)
        {
            //value.Id = _nextId++;
            DateTime now = DateTime.Now;
            string nowStr = now.ToString("yyyy-MM-dd");
            value.Date = nowStr;
            _context.Bicycles.Add(value);
            //_context.SaveChangesAsync();
            int saved = _context.SaveChanges();
            return value;
        }

        /*/ PUT api/<BicyclesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<BicyclesController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            Bicycle cycle = _context.Bicycles.Find(id);
            if (cycle == null) return 0;
             _context.Bicycles.Remove(cycle);
             _context.SaveChanges();
             return 1;
        }
    }
}
