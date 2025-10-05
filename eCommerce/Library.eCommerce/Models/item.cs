using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.eCommerce.Services;
using Library.eCommerce.DTO;

namespace Library.eCommerce.Models
{
    public class Item
    {
        public int Id {get; set;}
        public ProductDTO Product {get; set;}
        public int? Quantity {get; set;}

        public double Price {get; set;}

        public override string ToString()
        {
            return $"{Product} Quantity:{Quantity}";
        }

        public string Display
        {
            get
            {
                return $"{Product?.Display ?? string.Empty} - {Quantity} - ${Price}";
            }
        }

        public Item()
        {
            Product = new ProductDTO();
            Quantity = 0;
        }
        public Item(Item i)
        {
            Product = new ProductDTO(i.Product);
            Quantity = i.Quantity;
            Id = i.Id;
            Price = i.Price;
        }
    }
}