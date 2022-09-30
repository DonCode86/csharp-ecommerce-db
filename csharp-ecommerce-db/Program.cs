// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("");
Console.WriteLine("Benvenuto! \npremi 1 per aggiungere un nuovo cliente \npremi 2 per aggiungere un nuovo prodotto");
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

    case 2:
        //create 
        Console.WriteLine("Inserisci il nome del prodotto");
        string productName = Console.ReadLine();

        Console.WriteLine("Inserisci la descrizione del prodotto");
        string productDescription = Console.ReadLine();

        Console.WriteLine("Inserisci il prezzo del prodotto");
        double productPrice = Convert.ToInt32(Console.ReadLine());

        EcommerceContext db2 = new EcommerceContext();
        Product newProduct = new Product();
        newProduct.Name = productName;
        newProduct.Description = productDescription;
        newProduct.Price = productPrice;
        db2.Add(newProduct);
        db2.SaveChanges();
        Console.WriteLine("Prodotto aggiunto correttamente!");



        //read 
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Ecco la lista Prodotti aggiornata:");
        Console.WriteLine("");
        List<Product> products = db2.Products.OrderBy(product => product.Name).ToList<Product>();

        foreach (Product product in products)
        {
            Console.WriteLine("Nome prodotto: " + product.Name + "\n" + "Descrizione prodotto: " + product.Description + "\n" + "Prezzo: " + product.Price + " Euro");
            Console.WriteLine("---------------------------------");
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




