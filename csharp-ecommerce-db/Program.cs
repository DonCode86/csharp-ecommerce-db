// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("");

//create 

EcommerceContext db = new EcommerceContext();
//Customer newCustomer = new Customer();
//newCustomer.Name = "Daniele";
//newCustomer.Surname = "Ciccarelli";
//newCustomer.Email = "doncicca@gmail.com";
//db.Add(newCustomer);
//db.SaveChanges();

//read 

Console.WriteLine("Recupero Lista Utenti:");
List<Customer> customers = db.Customers.OrderBy(customer => customer.Name).ToList<Customer>();

foreach(Customer customer in customers)
{
    Console.WriteLine(customer.Name + " " + customer.Surname + " ------> " + customer.Email);
}

//Update
customers[0].Email = "email@modificata.it";
    db.SaveChanges();

public class EcommerceContext: DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Payment> Payments { get; set; }

    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-ecommerce;Integrated Security=True");
    }
}




