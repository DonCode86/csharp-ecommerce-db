// See https://aka.ms/new-console-template for more information
public class Order
{
    public int Id { get; set; }

    public int Employee_id { get; set; }

    public Employee Employee { get; set; }

    public DateOnly Date { get; set; }

    public int Amount { get; set; }

    public string Status { get; set; }

    public int Customer_id { get; set; }
    public Customer Customer { get; set; }  

    public List <Payment> Payments { get; set; }

    public List <Product> Products { get; set; }

}

