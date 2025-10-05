using System.Threading.Tasks;
using Library.eCommerce.Models;
using Library.eCommerce.DTO;

namespace Classwork.Models
{
    public class Product
    {
        public int Id {get; set;}

        public string? Name {get; set;}

        public double Price {get; set;}

        public string? Display
        {
            get
            {
                return $"{Id}. {Name}";
            }
        }

        public string? LegacyProperty1 {get; set;}
        public string? LegacyProperty2 {get; set;}
        public string? LegacyProperty3 {get; set;}
        public string? LegacyProperty4 {get; set;}
        public string? LegacyProperty5 {get; set;}
        public string? LegacyProperty6 {get; set;}

        public Product()
        {
            Name = string.Empty;
        }

        public Product(Product product)
        {
                if (product == null) throw new ArgumentNullException(nameof(product));

                Id = product.Id;
                Name = product.Name;
        }

        public Product(ProductDTO p)
        {
            Name = p.Name;
            Id = p.Id;
            LegacyProperty1 = string.Empty;       //ADD LEGACY PROPERTY TO PRODUCTDTO
        }

        public override string ToString()
        {
            return Display ?? string.Empty;
        }
    }
}