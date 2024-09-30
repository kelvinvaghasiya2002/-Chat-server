using ChatApp.Data;
using ChatApp.Models;
using ChatApp.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees =  dbContext.Employees.ToList();
            return Ok(allEmployees);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto employeeDto)
        {
            var employeeEntity = new Employee()
            {
                Email = employeeDto.Email,
                Name = employeeDto.Name,
                salary = employeeDto.salary
            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();
            return Ok(employeeEntity);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = dbContext.Employees.Find(id);
            if(employee==null) return NotFound();
            return Ok(employee);
        }
    }
}
