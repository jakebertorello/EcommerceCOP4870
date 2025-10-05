using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.eCommerce.Services;
using Library.eCommerce.Models;
using Intents;

namespace Maui.eCommerce.ViewModels
{
    public class CheckoutViewModel : INotifyPropertyChanged
    {
        private ShoppingCartService _chksvc = ShoppingCartService.Current;
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName is null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public double Total
        {
            get 
            {
                var num = Math.Round(_chksvc.subtotal + (_chksvc.subtotal * .07), 2);
                return num;
            }
            set
            {
                _chksvc.subtotal = value;
            }
        }

        public void RefreshUX()
        {
            NotifyPropertyChanged(nameof(CheckoutCart));
            NotifyPropertyChanged(nameof(Total));
        }

        public ObservableCollection<ItemViewModel?> CheckoutCart
        {
            get
            {
                double cost = 0;
                foreach (var item in _chksvc.CartItems)
                {
                    for(int i = 0; i<item?.Quantity; i++)
                    cost += item?.Price ?? 0;
                }
                Total = cost;
                NotifyPropertyChanged(nameof(Total));
                return new ObservableCollection<ItemViewModel?>(_chksvc.CartItems
                    .Where(i => i?.Quantity > 0).Select(m => new ItemViewModel(m))
                    );
            }
        }

        public void Purchase()
        {
            Application.Current?.Quit();
        }
    }
}
