using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CorpWatchApi.Models;

namespace CorpWatchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : Controller
    {
        ApplicationDbContext _db;

        public JobController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        
        /*private readonly JobContext _context;

        public JobController(JobContext context)
        {
            _context = context;

            if (_context.Jobs.Count() == 0)
            {
                // Create a new Job if collection is empty,
                // which means you can't delete all Jobs.
                _context.Jobs.Add(new Job { Name = "Walker Project" });
                _context.SaveChanges();
            }
        }*/

        [HttpGet]
        public List<Job> Get()
        {
            return _db.Jobs.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Job> GetById(long id)
        {
            var job = _db.Jobs.Find(id);
            if (job == null)
            {
                return NotFound();
            }
            return job;
        }

        [HttpPost]
        public IActionResult Create(Job Job)
        {
            _db.Jobs.Add(Job);
            _db.SaveChanges();

            return CreatedAtRoute("GetJob", new { id = Job.Id }, Job);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Job job)
        {
            var Job = _db.Jobs.Find(id);
            if (Job == null)
            {
                return NotFound();
            }

            Job.IsComplete = job.IsComplete;
            Job.Name = job.Name;

            _db.Jobs.Update(job);
            _db.SaveChanges();
            return NoContent();
        }
        

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var job = _db.Jobs.Find(id);
            if (job == null)
            {
                return NotFound();
            }

            _db.Jobs.Remove(job);
            _db.SaveChanges();
            return NoContent();
        }
    }
}