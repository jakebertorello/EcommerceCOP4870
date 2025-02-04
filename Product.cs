using System.Threading.Tasks;


public class Product
{
    public int Id {get; set;}
    public int quantity {get; set;}

    private string name;

    public string? Name {get; set;}

    public string? Display
    {
        get
        {
            return $"{Id}. {Name} - {quantity}";
        }
    }

    public Product()
    {
        name = string.Empty;
    }

    public override string ToString()
    {
        return Display ?? string.Empty;
    }
}