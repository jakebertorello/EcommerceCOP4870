using System;
using Library.eCommerce.Models;
using Library.eCommerce.Services;

namespace Maui.eCommerce.ViewModels
{
    public class ProductViewModel
    {
        private Item? cachedModel {get; set;}
        public string? Name {
            get
            {
                return Model?.Product?.Name ?? string.Empty;
            }

            set
            {
                if(Model != null && Model.Product?.Name != value)
                {
                    Model.Product.Name = value;
                }
            }
        }

        public int? Quantity
        {
            get
            {
                return Model?.Quantity;
            }
            set
            {
                if(Model != null && value != null && Model.Quantity != value)
                {
                    Model.Quantity = value;
                }
            }
        }

        public double? Price
        {
            get
            {
                return Model?.Price;
            }
            set
            {
                if(Model != null && value != null && Model.Price != value)
                {
                    Model.Price = value ?? 0;
                }
            }
        }

        public Item? Model {get; set;}

        public void AddOrUpdate()
        {
            ProductServiceProxy.Current.AddOrUpdate(Model);
        }

        public void Undo()
        {
            if(cachedModel != null){
                ProductServiceProxy.Current.AddOrUpdate(cachedModel);
            }

        }

        public ProductViewModel()
        {
            Model = new Item();
        }

        public ProductViewModel(Item? model)
        {
            Model = model;
            if(model != null)
            {
                cachedModel = new Item(model);
            }
        }
    }
}