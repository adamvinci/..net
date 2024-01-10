
using ConsoleApp2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static System.Console;

WriteLine("Numéro d'exercice à exécuter (Exemple : B1)");
string? exerciceNumber = ReadLine();

if (exerciceNumber is not null)
{
    switch (exerciceNumber)
    {
        case "1":
            ex1();
            break;
        case "2":
            ex2();
            break;
        case "3":
            ex3();
            break;
        case "4":
            ex4();
            break;
        case "5":
            ex5();
            break;
        case "6":
            ex6();
            break;
        case "7":
            exc();
            break;
        case "8":
            exb();
            break;
        case "9":
            exe();
            break;
        default:
            WriteLine("numéro d'exerice inconnu");
            break;

    }
}

static void ex1(){
    String? ville = Console.ReadLine();
    WriteLine("Entrer le nom de la ville");
    using(NorthwindContext northwindContext = new NorthwindContext())
    {
        var customers = northwindContext.Customers.Where(c => c.City == ville).Select(e => e.ContactName);
        foreach(var customer in customers)
        {
                Console.WriteLine(customer);
        }
    }
}

static void ex2()
{

    using (NorthwindContext northwindContext = new NorthwindContext())
    {
        var products = northwindContext.Categories.Where(c=>c.CategoryName =="Beverages" || c.CategoryName == "Condiments").Select(c => new {c.CategoryName,product= c.Products });
        foreach (var productPerCategory in products)
        {
            Console.WriteLine(productPerCategory.CategoryName);
            foreach(Product product in productPerCategory.product)
            {
                Console.WriteLine(product.ProductName + " " + product.Category.CategoryName);
            }
        }
    }
}

static void ex2Eager()
{

    using (NorthwindContext northwindContext = new NorthwindContext())
    {
        var products = northwindContext.Categories.Include("Products").Where(c => c.CategoryName == "Beverages" || c.CategoryName == "Condiments").Select(c => new { c.CategoryName, product = c.Products });
        foreach (var productPerCategory in products)
        {
            Console.WriteLine(productPerCategory.CategoryName);
            foreach (Product product in productPerCategory.product)
            {
                Console.WriteLine(product.ProductName );
            }
        }
    }
}

static void ex3()
{


        String? customer = ReadLine();
        using (NorthwindContext context = new NorthwindContext())
        {
            var listCommandesClient = context.Orders.Where(o => o.ShippedDate != null && o.CustomerId == customer)
                .Select(order => new { order.CustomerId, order.OrderDate, order.ShippedDate }).OrderByDescending(o => o.OrderDate);
            foreach(var order in listCommandesClient)
            {
                Console.WriteLine(order);
            }

        }
    
}

static void ex4()
{


        using (NorthwindContext context = new NorthwindContext())
        {
            var totalVentesPerProduct = context.Products.Select(p => new {p.ProductId,total=p.OrderDetails.Sum(o => o.Quantity*o.UnitPrice)});
            foreach (var order in totalVentesPerProduct)
            {
                Console.WriteLine(order);
            }

        
    }
}

static void ex5()
{


    using (NorthwindContext context = new NorthwindContext())
    {
        var employeResponsableWestern = context.Employees.Where(e => e.Territories.Any(t => t.Region.RegionDescription == "Western")).Select(e => e.FirstName);
        foreach (var order in employeResponsableWestern)
        {
            Console.WriteLine(order);
        }


    }
}

static void ex6()
{


    using (NorthwindContext context = new NorthwindContext())
    {
        var territoryManagedBySumayaSupervisor = context.Employees.Where(e => e.FirstName == "Michael" && e.LastName == "Suyama")
            .Select(e => e.ReportsToNavigation.Territories).SingleOrDefault();
        foreach (var order in territoryManagedBySumayaSupervisor)
        {
     
                Console.WriteLine(order.TerritoryDescription);
            
        }


    }
}

static void exc()
{


    using (NorthwindContext context = new NorthwindContext())
    {
        IList<Customer> customers = context.Customers.ToList();
        foreach (var item in customers)
        {
            item.ContactName = item.ContactName.ToUpper();
        }
        context.SaveChanges();
    foreach(var customer in customers)
        {
            Console.WriteLine(customer.ContactName);
        }
    }

}

static void exb()
{
    Console.WriteLine("ajoute une categorie");

    String category = ReadLine();
    using (NorthwindContext context = new NorthwindContext())
    {
        Category newCategory = new Category{ CategoryName=category};
     
        context.Categories.Add(newCategory);
        context.SaveChanges();
        foreach (var categori in context.Categories)
        {
            Console.WriteLine(categori.CategoryName);
        }
    }

}

static void exe()
{

    using (NorthwindContext context = new NorthwindContext())
    {

        context.Categories.Remove(context.Categories.Where(c=>c.CategoryName=="caca").First());
        context.SaveChanges();
        foreach (var categori in context.Categories)
        {
            Console.WriteLine(categori.CategoryName);
        }
    }

}