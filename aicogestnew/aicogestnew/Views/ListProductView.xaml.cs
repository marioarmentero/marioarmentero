using aicogestnew.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aicogestnew.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListProductView : ContentPage
    {
        ListProductViewModel _viewModel;
        public ListProductView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ListProductViewModel(Navigation);
          
        }
    }
}