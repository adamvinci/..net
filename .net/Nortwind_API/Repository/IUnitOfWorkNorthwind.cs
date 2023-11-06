
using Northwind_API.Entities;
using Nortwind_API.Models;

namespace Northwind_API.Repositories
{
    interface IUnitOfWorkNorthwind
    {
        IRepository<Employee> EmployeesRepository { get; }

        IRepository<Order> OrdersRepository { get; }
    }
}
