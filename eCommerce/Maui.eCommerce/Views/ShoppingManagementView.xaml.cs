using Library.eCommerce.Services;
using Maui.eCommerce.ViewModels;
using System.ComponentModel;

namespace Maui.eCommerce.Views
{

public partial class ShoppingManagementView : ContentPage
    {
        public ShoppingManagementView()
        {
            InitializeComponent();
            BindingContext = new ShoppingManagementViewModel();
        }
        private void RemoveFromCartClicked(object sender, EventArgs e)
        {
            (BindingContext as ShoppingManagementViewModel)?.ReturnItem();
        }

        private void AddToCartClicked(object sender, EventArgs e)
        {
            (BindingContext as ShoppingManagementViewModel)?.PurchaseItem();
        }

        
        private void InLineAddClicked(object sender, EventArgs e)
        {
            (BindingContext as ShoppingManagementViewModel)?.RefreshUX();
        }

        private void CheckoutClicked(object sender, EventArgs e)
        {
            (BindingContext as ShoppingManagementViewModel)?.Checkout();
            Shell.Current.GoToAsync($"//CheckoutView");
        }
    }
}