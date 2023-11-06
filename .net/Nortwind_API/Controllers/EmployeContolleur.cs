using Microsoft.AspNetCore.Mvc;
using Northwind_API.Entities;
using Northwind_API.Repositories;
using Nortwind_API.DTO;
using Nortwind_API.Models;

namespace Nortwind_API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeContolleur : ControllerBase
    {
        private readonly NorthwindContext _dbcontext;
        private readonly IUnitOfWorkNorthwind _unitOfWorkNorthwind;

        public EmployeContolleur()
        {
            _dbcontext = new NorthwindContext();
            _unitOfWorkNorthwind = new UnitOfWorkNorthwindSQL(_dbcontext);
        }

        [HttpGet]
        public async Task<IList<EmployeeDTO>> getEmployeList()
        {
            IList<Employee> lst = await _unitOfWorkNorthwind.EmployeesRepository.GetAllAsync();
            return lst.Select(e => EmployeeToDTO(e)).ToList();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getEmploye(int id)
        {
            Employee? emp = await _unitOfWorkNorthwind.EmployeesRepository.GetByIdAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(EmployeeToDTO(emp));
            }

        }
        [HttpPost]
        public async Task addOne(EmployeeDTO emp)
        {
            emp.EmployeeId = 0;
            Employee empDb = DTOToEmployee(emp);
            await _unitOfWorkNorthwind.EmployeesRepository.SaveAsync(empDb);
        }
        [HttpPut]

        public async Task UpdateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            Employee e = DTOToEmployee(employeeDTO);
            await _unitOfWorkNorthwind.EmployeesRepository.SaveAsync(e);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteEmploye(int id)
        {
            Employee? emp = await _unitOfWorkNorthwind.EmployeesRepository.GetByIdAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWorkNorthwind.EmployeesRepository.DeleteAsync(emp);
                return Ok();
            }

        }
        private static EmployeeDTO EmployeeToDTO(Employee emp) =>
        new EmployeeDTO
        {
            EmployeeId = emp.EmployeeId,
            LastName = emp.LastName,
            FirstName = emp.FirstName,
            BirthDate = emp.BirthDate,
            HireDate = emp.HireDate,
            Title = emp.Title,
            TitleOfCourtesy = emp.TitleOfCourtesy

        };

        private static Employee DTOToEmployee(EmployeeDTO emp) =>
            new Employee
            {
                EmployeeId = emp.EmployeeId,
                LastName = emp.LastName,
                FirstName = emp.FirstName,
                BirthDate = emp.BirthDate,
                HireDate = emp.HireDate,
                Title = emp.Title,
                TitleOfCourtesy = emp.TitleOfCourtesy
            };
    }

};
      

      
