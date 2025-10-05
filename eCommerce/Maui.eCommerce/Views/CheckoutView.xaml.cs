using Maui.eCommerce.ViewModels;
using Library.eCommerce.Services;
using Library.eCommerce.Models;
using System.ComponentModel;

namespace Maui.eCommerce.Views;

public partial class CheckoutView : ContentPage
{
	public CheckoutView()
	{
		InitializeComponent();
		BindingContext = new CheckoutViewModel();
	}

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		(BindingContext as CheckoutViewModel)?.RefreshUX();
    }

    private void PurchaseClicked(object sender, EventArgs e)
    {
		(BindingContext as CheckoutViewModel)?.Purchase();
    }
}