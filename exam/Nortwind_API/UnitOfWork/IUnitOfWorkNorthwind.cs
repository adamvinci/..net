using Nortwind_API.Models;
using Nortwind_API.Repository;

namespace Nortwind_API.UnitOfWork
{
    public interface IUnitOfWorkNorthwind
    {
        IRepository<Employee> EmployeesRepository { get; }
        IRepository<Order> OrdersRepository { get; }
    }
}
