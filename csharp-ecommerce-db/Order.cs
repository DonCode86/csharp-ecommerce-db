// See https://aka.ms/new-console-template for more information
public class Order
{
    public int Id { get; set; }
    //Relazioni con employee 
    public int Employee_id { get; set; }

    public Employee Employee { get; set; }

    public DateOnly Date { get; set; }

    public int Amount { get; set; }

    public string Status { get; set; }

    //Relazioni con customer
    public int Customer_id { get; set; }
    public Customer Customer { get; set; }  

    //Relazioni con payment 
    public List <Payment> Payments { get; set; }
    
    //Relazioni con product
    public List <Product> Products { get; set; }

}

