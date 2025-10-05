using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.eCommerce.Models;
using Library.eCommerce.DTO;
using System.Net.Http.Headers;

namespace Library.eCommerce.Services
{
    public class ProductServiceProxy
    {
        private ProductServiceProxy()
        {
            Products = new List<Item?>()
            {
                new Item{Product = new ProductDTO{Id = 1, Name = "Product 1"}, Id = 1, Quantity = 5, Price = 3.99},
                new Item{Product = new ProductDTO{Id = 2, Name = "Product 2"}, Id = 2, Quantity = 10, Price = 6.99},
                new Item{Product = new ProductDTO{Id = 3, Name = "Product 3"}, Id = 3, Quantity = 15, Price = 18.99}
            };
        }

        private int LastKey
        {
            get
            {
                if(!Products.Any())
                {
                    return 0;
                }

                return Products.Select(p => p?.Id ?? 0).Max();
            }
        }

        private static ProductServiceProxy? instance;
        private static object instanceLock = new object();
        public static ProductServiceProxy Current
        {
            get
            {
                lock(instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new ProductServiceProxy();
                    }
                }
                return instance;
            }
        }

        public List<Item?> Products {get; private set;}

        public Item AddOrUpdate(Item item)
        {
            if(item.Id == 0)
            {
                item.Id = LastKey + 1;
                item.Product.Id = item.Id;
                Products.Add(item);
            }
            else
            {
                var existingItem = Products.FirstOrDefault(p => p?.Id == item.Id);
                var index = Products.IndexOf(existingItem);
                Products.RemoveAt(index);
                Products.Insert(index, new Item(item));
            }

            return item;
        }

        public Item? PurchaseItem(Item? item)
        {
            if(item?.Id <= 0 || item == null)
            {
                return null;
            }

            var itemToPurchase = FindById(item.Id);
            if(itemToPurchase != null)
            {
                itemToPurchase.Quantity--;
            }

            return itemToPurchase;
        }

        public Item? Delete(int id)
        {
            Item? item = FindById(id);
                Products.Remove(item);

            return item;
        }

        public Item? FindById(int id)
        {
            return Products.FirstOrDefault(p => p?.Id == id);
        }
    }
}
