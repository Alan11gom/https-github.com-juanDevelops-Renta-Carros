using Microsoft.Maui.Controls;
using MongoDB.Bson;

namespace Renta_Carros;

public partial class Prueba : ContentPage
{

    public Prueba()
    {
        InitializeComponent();
        if (true)
        {

        }
        BindingContext = null; // Establece el BindingContext en null
        BindingContext = new CarrosViewModel(); // Crea una nueva instancia de tu ViewModel y establece el BindingContext nuevamente
        ListaCarros.ItemsSource = (BindingContext as CarrosViewModel).CarrosCollection;
    }



    private async void btnRentar_Clicked(object sender, EventArgs e)
    {
        var tabbedPage = Application.Current.MainPage as Menu;
        RentarCarro rentarCarro = tabbedPage.Children[2] as RentarCarro;

        var carroSeleccionado = (Carros)ListaCarros.SelectedItem;

        if (carroSeleccionado != null)
        {
            rentarCarro.RellenarDatos(carroSeleccionado.Placas.ToString(), carroSeleccionado.Precio.ToString());
            tabbedPage.CurrentPage = rentarCarro;
            //var mensaje = $"Marca: {carroSeleccionado.Marca}\nModelo: {carroSeleccionado.Modelo}\nA�o: {carroSeleccionado.A�o}";
            //await DisplayAlert("Informaci�n del veh�culo", mensaje, "Ok");
        }
        else
        {
            await DisplayAlert("Error", "No se ha seleccionado ning�n veh�culo.", "Ok");
        }
    }

    private async void btnModificar_Clicked(object sender, EventArgs e)
    {
        var tabbedPage = Application.Current.MainPage as Menu;
        AgregarCarro modificarCarro = tabbedPage.Children[3] as AgregarCarro;

        var carroSeleccionado = (Carros)ListaCarros.SelectedItem;


        if (carroSeleccionado != null)
        {
            BsonBinaryData imageData = carroSeleccionado.Imagen;
            byte[] imageBytes = imageData.Bytes;
            ImageSource sourceImagen = ImageSource.FromStream(() => new MemoryStream(imageBytes));
            modificarCarro.RellenarDatos(carroSeleccionado.Marca.ToString(), carroSeleccionado.Modelo.ToString(), carroSeleccionado.A�o.ToString(), carroSeleccionado.Color.ToString(), carroSeleccionado.Placas.ToString(), carroSeleccionado.Precio.ToString(), sourceImagen, imageBytes);
            //var mensaje = $"Marca: {carroSeleccionado.Marca}\nModelo: {carroSeleccionado.Modelo}\nA�o: {carroSeleccionado.A�o}";
            //await DisplayAlert("Informaci�n del veh�culo", mensaje, "Ok");
            tabbedPage.CurrentPage = modificarCarro;
        }
        else
        { 
            var tabbedPageMenu = Application.Current.MainPage as Menu;
            Menu menu = tabbedPageMenu as Menu;


            await DisplayAlert("Error", menu.ipv4, "Ok");
            await DisplayAlert("Error", "No se ha seleccionado ning�n veh�culo.", "Ok");
        }
    }

    public void btnActualizar_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PopAsync();
        //await Navigation.PushAsync(new Prueba());
        BindingContext = null; // Establece el BindingContext en null
        BindingContext = new CarrosViewModel(); // Crea una nueva instancia de tu ViewModel y establece el BindingContext nuevamente
        ListaCarros.ItemsSource = (BindingContext as CarrosViewModel).CarrosCollection;
    }

    public void ActualizarLista()
    {
        BindingContext = null; // Establece el BindingContext en null
        BindingContext = new CarrosViewModel(); // Crea una nueva instancia de tu ViewModel y establece el BindingContext nuevamente
        ListaCarros.ItemsSource = (BindingContext as CarrosViewModel).CarrosCollection;
    }
}
