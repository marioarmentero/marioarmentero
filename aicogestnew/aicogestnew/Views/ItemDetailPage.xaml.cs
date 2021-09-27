using aicogestnew.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace aicogestnew.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}