using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace aicogestnew.ViewModels
{
   public class ProductViewModel: BaseViewModel
    {
        private string _id;

        public string id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }

        private string _itemName;
        public string itemName
        {
            get { return _itemName; }
            set { _itemName = value; OnPropertyChanged(); }
        }
        private int _stock;
        public int stock
        {
            get { return _stock; }
            set { _stock = value; OnPropertyChanged(); }
        }

        private decimal _price;
        public decimal price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(); }
        }

        public ICommand ClearCommand { private set; get; }
        public ICommand SendEmailCommand { private set; get; }
        public ProductViewModel()
        {
            ClearCommand = new Command(() => Clear());
            SendEmailCommand = new Command(async () => await SendEmail());
        }

        void Clear()
        {
            itemName = string.Empty;
            price = 0;
            stock = 0;

        }

        async Task SendEmail()
        {
            itemName = "Esto es un mensaje";
        }

    }
}
