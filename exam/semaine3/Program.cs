
using Microsoft.EntityFrameworkCore;
using semaine3.Models;

using (NorthwindContext context = new NorthwindContext())
{

}

    using (NorthwindContext context = new NorthwindContext())
{
    Category category = context.Categories.Where(c=>c.CategoryName== "aaaaaaa").FirstOrDefault();
    context.Categories.Remove(category);
    context.SaveChanges();
    var listCategorue = context.Categories.ToList();
    foreach (var item in listCategorue)
    {
        Console.WriteLine(item.CategoryName);
    }
}
Console.ReadLine();

using (NorthwindContext context = new NorthwindContext())
{
    string? newCategory = Console.ReadLine();
    Category category = new Category();
    category.CategoryName = newCategory;
    context.Categories.Add(category);
    context.SaveChanges();
    var listCategorue=context.Categories.ToList();
    foreach(var item in listCategorue)
    {
           Console.WriteLine(item.CategoryName);
    }
  
}



    using (NorthwindContext context = new NorthwindContext())
{

    foreach (Customer customer in context.Customers)
    {
        customer.ContactName = customer.ContactName.ToUpper();
    }
    context.SaveChanges();
    foreach (Customer customer in context.Customers)
    {
        Console.WriteLine(customer.ContactName);

    }
}


using (NorthwindContext context = new NorthwindContext())
{
    var territoryEmployeSuperior = from emp in context.Employees
                                   where emp.LastName=="Suyama"
                                   select  new { list= emp.ReportsToNavigation.Territories.Select(t=>t.TerritoryDescription) };

    foreach (var terriory in territoryEmployeSuperior)
    {
        foreach(var item in terriory.list)
        {
            Console.WriteLine(item);
        }
        
    }
}


using (NorthwindContext context = new NorthwindContext())
{
    var territoryEmploye = from emp in context.Employees
                           where emp.Territories.Any(t => t.Region.RegionDescription == "Western")
                           select new { name = emp.LastName + " " + emp.FirstName };

    foreach (var empploye in territoryEmploye)
    {
        Console.WriteLine(empploye.name);
    }
}



using (NorthwindContext context = new NorthwindContext())
{
    var totalSalesPerProduct = from p in context.Products
                               orderby p.ProductId
                               select new { p.ProductId, sum= p.OrderDetails.Sum(o =>o.UnitPrice* o.Quantity) };
    foreach (var product in totalSalesPerProduct)
    {
        Console.WriteLine(product.ProductId + "------->" + product.sum);
    }
}

using (NorthwindContext dc = new NorthwindContext())
{

    Console.WriteLine("Veuillez entrer un client : ");
    string userInput = Console.ReadLine();

    var orderPerCustomer = from order in dc.Orders
                           where order.Customer.CustomerId == userInput && order.ShippedDate != null
                           select new { CustomerId = order.Customer.ContactName, order.OrderDate, order.ShippedDate };
    foreach (var order in orderPerCustomer)
    {
        Console.WriteLine(order);
    }
}




using (NorthwindContext dc = new NorthwindContext())
{
    var produitsCategory = from c in dc.Categories
                           where (c.CategoryName == "Beverages" || c.CategoryName == "Condiments")
                           select c;
    foreach (Category category in produitsCategory)
    {
        Console.WriteLine(category.CategoryName);
        foreach (Product product in category.Products)
        {
            Console.WriteLine(product.ProductName);
        }
    }

    foreach (var product in produitsCategory)
    {
        Console.WriteLine(product);
    }

}





using (NorthwindContext dc = new NorthwindContext())
{

    Console.WriteLine("Veuillez entrer une ville : ");
    string userInput = Console.ReadLine();

    var customersPerCity = from c in dc.Customers
                           where c.City.Equals(userInput)
                           select c;
    foreach (var customer in customersPerCity)
    {
        Console.WriteLine(customer.ContactName);
    }
}
