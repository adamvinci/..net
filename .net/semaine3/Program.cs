
using Microsoft.EntityFrameworkCore;
using semaine3.Models;

NorthwindContext  northwind = new NorthwindContext();

Console.WriteLine("-------------------------------1-----------------------------------");
Console.WriteLine("Entrer le nom d'une ville");
String cityName=Console.ReadLine();
var customerPerCity = northwind.Customers.Where(c => c.City.Equals(cityName)).Select(c=>new {c});   
foreach (var c in customerPerCity)
{
    Console.WriteLine("{0}",c.c.ContactName);
}

Console.WriteLine("-------------------------------2-----------------------------------");

var productPerCategory = from category in northwind.Categories
                         join product in northwind.Products on category.CategoryId equals product.CategoryId into products
                         where category.CategoryName == "Beverages" || category.CategoryName == "Condiments"
                         select new {Categorie=category.CategoryName,produits=products};
foreach (var product in productPerCategory)
{
    Console.WriteLine("{0} ", product.Categorie);
    foreach(var c in product.produits)
    {
        Console.WriteLine("{0}", c.ProductName);
    }
}

Console.WriteLine("-------------------------------3-----------------------------------");
var productPerCategoryEager = from category in northwind.Categories
            .Include(c => c.Products) 
            where category.CategoryName == "Beverages" || category.CategoryName == "Condiments"
            select new
            {
                Categorie = category.CategoryName,
                produits = category.Products
            };
foreach (var product in productPerCategoryEager)
{
    Console.WriteLine("{0} ", product.Categorie);
    foreach (var c in product.produits)
    {
        Console.WriteLine("{0}", c.ProductName);
    }
}


Console.WriteLine("-------------------------------4-----------------------------------");
Console.WriteLine("Entrer le nom d'un client");
String clientName = Console.ReadLine();
var clientOrder = (from client in northwind.Customers
                  join order in northwind.Orders on client.CustomerId equals order.CustomerId 
                  where client.CustomerId == clientName && order.ShippedDate != null
                  select new { client = client.CustomerId, dateComande = order.OrderDate,dateShipping = order.ShippedDate }).OrderByDescending(item=>item.dateShipping);
foreach(var client in clientOrder)
{
    Console.WriteLine("Customer ID : {0} OrderDate :  {1} ShippedDate : {2}", client.client, client.dateComande, client.dateShipping);
}



Console.WriteLine("-------------------------------5-----------------------------------"); //marche pas

var salesPerProductjoin = from p in northwind.Products
                           join orderDetail in northwind.OrderDetails on p.ProductId equals orderDetail.ProductId into sales
                           select new
                           {
                               id = p.ProductId,
                               total = sales.Sum(s => s.Quantity)
                           };

foreach (var sales in salesPerProductjoin)
{
    Console.WriteLine("{0} {1}", sales.id, sales.total);
}

Console.WriteLine("-------------------------------6-----------------------------------");

var employeWestern = from employee in northwind.Employees
            where employee.Territories.Any(t => (from territoire in northwind.Territories
                     join region in northwind.Regions on territoire.RegionId equals region.RegionId
                     where region.RegionDescription == "Western" 
                     select territoire.TerritoryId)
                .Contains(t.TerritoryId))
            select new { name = employee.FirstName + " " + employee.LastName };


foreach (var item in employeWestern)
{
    Console.WriteLine("{0} ", item.name);
}

Console.WriteLine("-------------------------------7-----------------------------------");

var territorySuperiorOfSumaya = from employee in northwind.Employees
                                join manager in northwind.Employees on employee.ReportsTo equals manager.EmployeeId
                                where employee.FirstName == "Michael" && employee.LastName == "Suyama"
                                select new
                                {
                                    name = manager.FirstName + " "+ manager.LastName,
                                    list = manager.Territories
                                };
foreach(var item in territorySuperiorOfSumaya)
{
    Console.WriteLine("{0}", item.name);
    foreach(var list in item.list)
    {
        Console.WriteLine("{0}", list.TerritoryDescription);
    }
}

Console.WriteLine("-------------------------------C-----------------------------------");

var employe = from Employee in northwind.Employees
              select Employee;
foreach (var item in employe)
{
    item.LastName = item.LastName.ToUpper();
}

    northwind.SaveChanges();

var lastnameClient = northwind.Employees.Select(x => x.LastName).ToList();

foreach(var item in lastnameClient)
{
    Console.WriteLine("{0}", item);
}

Console.WriteLine("-------------------------------D-----------------------------------");

Console.WriteLine("Enter le nom d'une categorie");
String categoryname = Console.ReadLine();
Category newCategory = new Category();
newCategory.CategoryName = categoryname;
northwind.Categories.Add(newCategory);
northwind.SaveChanges();

var categoryName = northwind.Categories.Select(x => x).ToList();

foreach (var item in categoryName)
{
    Console.WriteLine("{0} {1}", item.CategoryName,item.CategoryId);
}

Console.WriteLine("-------------------------------E-----------------------------------");

Console.WriteLine("Enter le nom d'une categorie a delete");
String categorytodelete = Console.ReadLine();
northwind.Categories.Remove(northwind.Categories.Where(c=>c.CategoryName == categorytodelete).First());
northwind.SaveChanges();

var categoryNameAfterDelete = northwind.Categories.Select(x => x).ToList();

foreach (var item in categoryNameAfterDelete)
{
    Console.WriteLine("{0} {1}", item.CategoryName, item.CategoryId);
}

Console.WriteLine("Enter le nom du employe a delete");
String employe1 = Console.ReadLine();
Console.WriteLine("Enter le nom du employe a transferer");
String employe2 = Console.ReadLine();

var orderofemploye2beforechange = northwind.Orders.Where(o => o.EmployeeId == int.Parse(employe2)).Select(o => o);
Console.WriteLine("Nombre d'order avant swap : {0}",orderofemploye2beforechange.Count());

foreach (var item in categoryName)
{
    Console.WriteLine("{0} {1}", item.CategoryName, item.CategoryId);
}

var orderperemplye1 = northwind.Orders.Where(o=>o.EmployeeId == int.Parse(employe1)).Select(o=>o);
foreach(var order in orderperemplye1)
{
    order.EmployeeId = int.Parse(employe2);
}

northwind.SaveChanges();

var orderofemploye2afterchange = northwind.Orders.Where(o => o.EmployeeId == int.Parse(employe2)).Select(o => o);
Console.WriteLine("Nombre d'order apres swap : {0}",  orderofemploye2afterchange.Count());