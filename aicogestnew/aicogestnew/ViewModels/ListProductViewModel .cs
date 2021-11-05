using aicogestnew.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace aicogestnew.ViewModels
{
    class ListProductViewModel:BaseViewModel
    {
        private ObservableCollection<Producto> _products;
        public Command LoadItemsCommand { get; }
        public ObservableCollection<Producto> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged(); }
        }

        private Producto _selectedProduct;

        public Producto SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged(); }
        }
        public ICommand GoToDetailsCommand { private set; get; }

        public INavigation Navigation { get; set; }

        public ListProductViewModel(INavigation navigation)
        {
            Title = "Lista de Productos";
            Products = new ObservableCollection<Producto>();
            
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            
            Navigation = navigation;
            GoToDetailsCommand = new Command<Type>(async (pageType) => await GoToDetails(pageType));
            Title = Title + " cant--> " + Products.Count;

        }


        async Task GoToDetails(Type pageType)
        {
            if (SelectedProduct != null)
            {
                var page = (Page)Activator.CreateInstance(pageType);

                page.BindingContext = new ProductViewModel()
                {
                    id = SelectedProduct.id.ToString(),
                    itemName=SelectedProduct.itemName,
                    price=SelectedProduct.price,
                    stock=SelectedProduct.stock       
                };
                await Shell.Current.GoToAsync(nameof(page));
               
            }
        }
        public async Task<List<Producto>> GetProductos()
        {        
                var credentials = new NetworkCredential("vabowl", "P3lvmt3n");
                var handler = new HttpClientHandler { Credentials = credentials };
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient(handler);
                List<Producto> Model = null;
     
                var response = await client.GetAsync("http://167.86.119.48:83/api/items");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();

                    Model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Producto>>(jsonstring);
                  
                    return Model;

                }
                else
                {
                    return null;
                }            
        }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Products.Clear();
                List<Producto> items = await GetProductos();
                foreach (Producto item in items)
                {
                    Products.Add(item);
                }
            }
            catch (Exception ex)
            {
             // _products.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
