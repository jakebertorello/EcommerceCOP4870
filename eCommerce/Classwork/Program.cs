using System.Xml.Serialization;

using System;

using System.Runtime.CompilerServices;
using Library.eCommerce.Services;
using Library.eCommerce.DTO;
using Classwork.Models;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Amazon!");

            char choice;
            do
            {
                Console.WriteLine("S. Shopping\nI. Inventory\nQ. Quit");
                string? input = Console.ReadLine() ?? string.Empty;
                choice = input[0];
                switch(choice)
                {
                    case 'I':
                    case 'i':
                    do
                    {
                        Console.WriteLine("C. Create new inventory item");
                        Console.WriteLine("R. Read all inventory items");
                        Console.WriteLine("U. Update an inventory item");
                        Console.WriteLine("D. Delete an inventory item");
                        Console.WriteLine("B. Go Back");
                        string? input1 = Console.ReadLine();
                        choice = input1[0];
                        switch(choice)
                        {
                            case 'C':
                            case 'c':
                                Console.WriteLine("Enter item and quantity");
                                ProductServiceProxy.Current.AddOrUpdate(new Product
                                {
                                    Name = Console.ReadLine(),
                                    
                                    
                                    Quantity = int.Parse(Console.ReadLine() ?? "-1")
                                });
                                break;
                            case 'R':
                            case 'r':
                                list.ForEach(Console.WriteLine);
                                break;
                            case 'U':
                            case 'u':
                                Console.WriteLine("Which product would you like to update?");
                                int selection = int.Parse(Console.ReadLine() ?? "-1");
                                var selectedProd = list.FirstOrDefault(p => p?.Id == selection);

                                if(selectedProd != null)
                                {
                                    Console.WriteLine("New item name");
                                    selectedProd.Name = Console.ReadLine() ?? "Error";
                                    ProductServiceProxy.Current.AddOrUpdate(selectedProd);
                                    Console.WriteLine("New item quantity");
                                    selectedProd.quantity = Console.Read();
                                    if(selectedProd.quantity < 0)
                                    {
                                        selectedProd.quantity = 0;
                                    }
                                }
                                break;
                            case 'D':
                            case 'd':
                                Console.WriteLine("Which product would you like to delete? (Enter ID Number)");
                                selection = int.Parse(Console.ReadLine() ?? "-1");
                                Console.WriteLine("How Many?");
                                int quant = int.Parse(Console.ReadLine() ?? "-1");
                                ProductServiceProxy.Current.Delete(selection);
                                break;
                            case 'B':
                            case 'b':
                                break;
                            default:
                                Console.WriteLine("Error. Unknown Command.");
                                break;
                        }
                    } while (choice != 'B' && choice != 'b');
                        break;
                    case 'S':
                    case 's':
                    do
                    {
                        Console.WriteLine("A. Add item to cart");
                        Console.WriteLine("R. Read all cart items");
                        Console.WriteLine("U. Update number of items in cart");
                        Console.WriteLine("D. Delete an item from cart");
                        Console.WriteLine("B. Go back");
                        string? input2 = Console.ReadLine();
                        choice = input2[0];
                        switch(choice)
                        {
                            case 'A':
                            case 'a':
                                Console.WriteLine("What number item would you like to add to cart? (Enter ID Number)");
                                int selection = int.Parse(Console.ReadLine() ?? "-1");
                                Console.WriteLine("How many?");
                                int quant = int.Parse(Console.ReadLine() ?? "-1");
                                Product? item = ProductServiceProxy.Current.FindById(selection);
                                ShoppingCartService.Current.AddOrUpdate(item);
                                ProductServiceProxy.Current.Delete(selection);
                                break;
                            case 'R':
                            case 'r':
                                cart.ForEach(Console.WriteLine);
                                break;
                            case 'U':
                            case 'u':
                                Console.WriteLine("Which product would you like to update?");
                                selection = int.Parse(Console.ReadLine() ?? "-1");
                                Console.WriteLine("Enter new quantity");
                                quant = int.Parse(Console.ReadLine() ?? "-1");
                                Product? item1 = ProductServiceProxy.Current.FindById(selection);

                                break;
                            case 'D':
                            case 'd':
                                Console.WriteLine("Which product would you like to remove?");
                                selection = int.Parse(Console.ReadLine() ?? "-1");
                                Product? delItem = ProductServiceProxy.Current.FindById(selection);
                                Console.WriteLine("How Many?");
                                quant = int.Parse(Console.ReadLine() ?? "-1");
                                ShoppingCartServiceProxy.Current.Delete(delItem, quant);
                                ProductServiceProxy.Current.AddOrUpdate(delItem);
                                break;
                            case 'B':
                            case 'b':
                                break;
                            default:
                                Console.WriteLine("Error. Unknown Command.");
                                break;
                        }
                    } while (choice != 'B' && choice != 'b');
                        break;
                }
            } while (choice != 'Q' && choice != 'q');
            ShoppingCartServiceProxy.Current.Checkout();
        }
    }
}