using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aicogestnew.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DocumentosScanner : ContentPage
    {
        static string subscriptionKey = "fa68ae2ad1b944f1b083fae64abc9f54";
        private const string READ_TEXT_URL_IMAGE = "https://intelligentkioskstore.blob.core.windows.net/visionapi/suggestedphotos/3.png";
        static string endpoint = "https://aicoffiapi.cognitiveservices.azure.com/";
        public DocumentosScanner()
        {
            InitializeComponent();
            //listView2.ItemTapped += ListitemTapped;

            var tapFoto = new TapGestureRecognizer();
            tapFoto.Tapped += async (s, e) =>
            {
                //Hacer una foto
                try
                {
                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await DisplayAlert("No Camera", ":( No camera available.", "OK");
                        return;
                    }

                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                    {
                        Directory = "Test",
                        SaveToAlbum = true,
                        CompressionQuality = 75,
                        CustomPhotoSize = 50,
                        PhotoSize = PhotoSize.MaxWidthHeight,
                        MaxWidthHeight = 2000,
                        DefaultCamera = CameraDevice.Front,
                        Name = $"{DateTime.UtcNow}.jpg"
                    });

                    if (file == null) return;
                    imgChoosed.Source = ImageSource.FromStream(() => {
                        var stream = file.GetStream();
                        return stream;
                    });

                    var cliente = Authenticate(endpoint, subscriptionKey);

                    var textHeaders = await cliente.ReadInStreamAsync(file.GetStream());

                    string operationLocation = textHeaders.OperationLocation;

                    const int numberOfCharsInOperationId = 36;
                    string operationId = operationLocation.Substring(operationLocation.Length - numberOfCharsInOperationId);

                    // Extract the text
                    ReadOperationResult results;
                   // Console.WriteLine($"Extracting text from URL file {Path.GetFileName(urlFile)}...");
                   // Console.WriteLine();
                    do
                    {
                        results = await cliente.GetReadResultAsync(Guid.Parse(operationId));
                    }
                    while ((results.Status == OperationStatusCodes.Running ||
                        results.Status == OperationStatusCodes.NotStarted));

                    var textUrlFileResults = results.AnalyzeResult.ReadResults;
                    foreach (ReadResult page in textUrlFileResults)
                    {
                        foreach (Line line in page.Lines)
                        {
                            txtCaptura.Text = txtCaptura.Text + line.Text + Environment.NewLine;
                        }
                    }


                    file.Dispose();
           

                }
                catch (Exception ex)
                {
                    await DisplayAlert("ERROR", ex.Message, "OK");
                }



            };
            ImgPhoto.GestureRecognizers.Add(tapFoto);

            //Imagen Search
            var tapSearch = new TapGestureRecognizer();
            tapSearch.Tapped += async (s, e) =>
            {
                //Galeria
                await CrossMedia.Current.Initialize();
                try
                {

                    var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                    {
                        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                    });
                    if (file == null) return;
                    imgChoosed.Source = ImageSource.FromStream(() => {
                        var stream = file.GetStream();
                        return stream;
                    });

                    var cliente = Authenticate(endpoint, subscriptionKey);

                    var textHeaders = await cliente.ReadInStreamAsync(file.GetStream());

                    string operationLocation = textHeaders.OperationLocation;

                    const int numberOfCharsInOperationId = 36;
                    string operationId = operationLocation.Substring(operationLocation.Length - numberOfCharsInOperationId);

                    // Extract the text
                    ReadOperationResult results;
                    // Console.WriteLine($"Extracting text from URL file {Path.GetFileName(urlFile)}...");
                    // Console.WriteLine();
                    do
                    {
                        results = await cliente.GetReadResultAsync(Guid.Parse(operationId));
                    }
                    while ((results.Status == OperationStatusCodes.Running ||
                        results.Status == OperationStatusCodes.NotStarted));

                    var textUrlFileResults = results.AnalyzeResult.ReadResults;
                    foreach (ReadResult page in textUrlFileResults)
                    {
                        foreach (Line line in page.Lines)
                        {
                            txtCaptura.Text = txtCaptura.Text + line.Text + Environment.NewLine;
                           // Console.WriteLine(line.Text);
                        }
                    }


                    file.Dispose();

                }
                catch (Exception ex)
                {
                    await DisplayAlert("ERROR", ex.Message, "OK");

                }

            };
            ImgSearch.GestureRecognizers.Add(tapSearch);
        }
        private async void ListitemTapped(object sender, ItemTappedEventArgs e)
        {
            await DisplayAlert("No hay referencia para el item ", "123456", "OK");

        }

        public static ComputerVisionClient Authenticate(string endpoint, string key)
        {
            ComputerVisionClient client =
              new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
              { Endpoint = endpoint };
            return client;
        }



    }
}