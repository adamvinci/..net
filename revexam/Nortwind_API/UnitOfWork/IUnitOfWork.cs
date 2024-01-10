using Nortwind_API.Controllers;
using Nortwind_API.Repository;
using Nortwind_API.Models
namespace Nortwind_API.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Employee> EmployeesRepository { get; }

        IRepository<Order> OrdersRepository { get; }

    }
}
