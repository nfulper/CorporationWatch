using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CorpWatchApi.Models;

namespace CorpWatchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
            

            if (_db.Employees.Count() == 0)
            {
                // Create a new Employee if collection is empty,
                // which means you can't delete all Employees.
                _db.Employees.Add(new Employee { FirstName = "Cosmo" });
                _db.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetAll()
        {
            return _db.Employees.ToList();
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        public ActionResult<Employee> GetById(long id)
        {
            var employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();

            return CreatedAtRoute("GetEmployee", new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Employee employee)
        {
            var Employee = _db.Employees.Find(id);
            if (Employee == null)
            {
                return NotFound();
            }

            Employee.Department = employee.Department;
            Employee.FirstName = employee.FirstName;
            Employee.LastName = employee.LastName;
            Employee.Jobs = employee.Jobs;

            _db.Employees.Update(Employee);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return NoContent();
        }
    }
}