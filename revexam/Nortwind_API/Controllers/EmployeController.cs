using Microsoft.AspNetCore.Mvc;
using Nortwind_API.DTO;
using Nortwind_API.Models;
using Nortwind_API.UnitOfWork;

namespace Nortwind_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeController : ControllerBase
    {
        private readonly NorthwindContext _northwindContext;
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<EmployeController> _logger;

        public EmployeController(ILogger<EmployeController> logger)
        {
            _logger = logger;
            _northwindContext = new NorthwindContext();
            _unitOfWork = new UnitOfWorkNorthwindSQL(_northwindContext);
        }

        [HttpGet]
        public async Task<ActionResult<IList<EmployeeDTO>>> GetAllEmploye()
        {
            IList<Employee> list = await _unitOfWork.EmployeesRepository.GetAllAsync();
            if(list == null) return NoContent();
            return Ok(list.Select(e => employeToDto(e)).ToList());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetOneEmploye(int id)
        {
           Employee emp= await _unitOfWork.EmployeesRepository.GetByIdAsync(id);
            if(emp == null) return NotFound();
            return Ok(employeToDto(emp));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDTO>> DeleteOneEmploye(int id)
        {
            Employee emp = await _unitOfWork.EmployeesRepository.GetByIdAsync(id);
            if (emp == null) return NotFound();
            await _unitOfWork.EmployeesRepository.DeleteAsync(emp);
            return Ok("deleted");
        }

        private static EmployeeDTO employeToDto(Employee employee) => new EmployeeDTO
        {
            EmployeeId = employee.EmployeeId,
            BirthDate = employee.BirthDate,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            HireDate = employee.HireDate,
            Title = employee.Title,
            TitleOfCourtesy = employee.TitleOfCourtesy,
        };

        private static Employee dtoToEmploye(EmployeeDTO employeeDTO) => new Employee
        {
            EmployeeId = employeeDTO.EmployeeId,
            BirthDate = employeeDTO.BirthDate,
            FirstName = employeeDTO.FirstName,
            LastName = employeeDTO.LastName,
            HireDate = employeeDTO.HireDate,
            Title = employeeDTO.Title,
            TitleOfCourtesy = employeeDTO.TitleOfCourtesy,
        };
    }
}