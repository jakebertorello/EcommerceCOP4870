using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.eCommerce.Services;
using Library.eCommerce.Models;

namespace Maui.eCommerce.ViewModels
{
    public class ItemViewModel
    {  
        public Item Model {get; set;}

        public ICommand? AddCommand {get; set;}

        private void DoAdd()
        {
            ShoppingCartService.Current.AddOrUpdate(Model);
        }

        void SetupCommands()
        {
            AddCommand = new Command(DoAdd);
        }

        public ItemViewModel()
        {
            Model = new Item();
            SetupCommands();
        }

        public ItemViewModel(Item model)
        {
            Model = model;
            SetupCommands();
        }
    }
}