using Microsoft.AspNetCore.Mvc;
using Nortwind_API.DTO;
using Nortwind_API.Models;
using Nortwind_API.Repository;
using Nortwind_API.UnitOfWork;

namespace Nortwind_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeControler : ControllerBase {
        private readonly NorthwindContext _dbcontext;
        private readonly IUnitOfWorkNorthwind _unitOfWorkNorthwind;

        public EmployeControler()
        {
            _dbcontext = new NorthwindContext();
            _unitOfWorkNorthwind = new UnitOfWorkNorthwindSQL(_dbcontext);

        }

        [HttpPost]
        public async Task InsertEmployeesAsync(EmployeeDTO employeeDTO)
        {
            // assure that id is not set to avoid error with autoincrement in database
            employeeDTO.EmployeeId = 0;
            Employee e = dtoToEmploye(employeeDTO);
            await _unitOfWorkNorthwind.EmployeesRepository.InsertAsync(e);
        }

        [HttpGet]
        public async Task<IList<EmployeeDTO>> getAll()
        {
            IList<Employee> employees = await _unitOfWorkNorthwind.EmployeesRepository.GetAllAsync();
            return employees.Select(e => employeToDto(e) ).ToList();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<EmployeeDTO>> getOne(int Id)
        {
            Employee employee = await _unitOfWorkNorthwind.EmployeesRepository.GetByIdAsync(Id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employeToDto(employee));
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> deleteOne(int Id)
        {
            Employee employee = await _unitOfWorkNorthwind.EmployeesRepository.GetByIdAsync(Id);
            if (employee == null)
            {
                return NotFound();
            }
            await _unitOfWorkNorthwind.EmployeesRepository.DeleteAsync(employee);
            return Ok();
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult> udpateOne(EmployeeDTO employeeDTO,int Id)
        {
            Employee employeeexist = await _unitOfWorkNorthwind.EmployeesRepository.GetByIdAsync(Id);
            if (employeeexist == null)
            {
                return NotFound();
            }
            employeeexist.FirstName = employeeDTO.FirstName !=null ? employeeDTO.FirstName : employeeexist.FirstName;
            employeeexist.LastName = employeeDTO.LastName;
            employeeexist.Title = employeeDTO.Title;
            employeeexist.TitleOfCourtesy = employeeDTO.TitleOfCourtesy;
            employeeexist.BirthDate = employeeDTO.BirthDate;
            await _unitOfWorkNorthwind.EmployeesRepository.SaveAsync(employeeexist);
            return Ok(employeeexist);
        }

        private static EmployeeDTO employeToDto(Employee employee)
        {
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName, 
                LastName = employee.LastName,
                Title = employee.Title,
                BirthDate = employee.BirthDate,
                TitleOfCourtesy = employee.TitleOfCourtesy,
            };
        }
        private static Employee dtoToEmploye(EmployeeDTO employe) =>
            new Employee
            {
                EmployeeId = employe.EmployeeId,    
                FirstName = employe.FirstName,
                LastName = employe.LastName,
                Title = employe.Title,
                BirthDate = employe.BirthDate,
                TitleOfCourtesy = employe.TitleOfCourtesy,

            };
    }
    
}
