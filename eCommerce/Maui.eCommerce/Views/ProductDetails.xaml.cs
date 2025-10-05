using Maui.eCommerce.ViewModels;
using Library.eCommerce.Services;

namespace Maui.eCommerce.Views;

[QueryProperty(nameof(ProductId), "productId")]

public partial class ProductDetails : ContentPage
{
	public ProductDetails()
	{
		InitializeComponent();
	}

	public int ProductId {get; set;}

	private void GoBackClicked (object sender, EventArgs e)
	{
		(BindingContext as ProductViewModel).Undo();
		Shell.Current.GoToAsync("//InventoryManagement");
	}

	private void OkClicked(object sender, EventArgs e)
	{
		(BindingContext as ProductViewModel).AddOrUpdate();
		Shell.Current.GoToAsync("//InventoryManagement");
	}

	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		if(ProductId == 0)
			BindingContext = new ProductViewModel();
		else
		{
			BindingContext = new ProductViewModel(ProductServiceProxy.Current.FindById(ProductId));
		}
	}
}