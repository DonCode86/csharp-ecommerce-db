// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("");
Console.WriteLine("Benvenuto! premi 1 per aggiungere un nuovo cliente");
int userChoice = Convert.ToInt32(Console.ReadLine());
switch (userChoice)
{
    case 1:
        //create 
        Console.WriteLine("Inserisci il nome del cliente");
        string customerName = Console.ReadLine();

        Console.WriteLine("Inserisci il cognome del cliente");
        string customerSurname = Console.ReadLine();

        Console.WriteLine("Inserisci email del cliente");
        string customerEmail = Console.ReadLine();



        EcommerceContext db = new EcommerceContext();
        Customer newCustomer = new Customer();
        newCustomer.Name = customerName;
        newCustomer.Surname = customerSurname;
        newCustomer.Email = customerEmail;
        db.Add(newCustomer);
        db.SaveChanges();
        Console.WriteLine("Cliente aggiunto correttamente!");



        //read 
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Ecco la lista Clienti aggiornata:");
        Console.WriteLine("");
        List<Customer> customers = db.Customers.OrderBy(customer => customer.Name).ToList<Customer>();

        foreach (Customer customer in customers)
        {
            Console.WriteLine(customer.Name + " " + customer.Surname + " ------> " + customer.Email);
        }
        break;
}


//Update
//customers[0].Email = "email@modificata.it";
    //db.SaveChanges();

//Remove
//db.Remove(customers[1]);
//db.SaveChanges();
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




