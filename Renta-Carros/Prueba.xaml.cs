namespace Renta_Carros;

public partial class Prueba : ContentPage
{
    public Prueba()
    {
        InitializeComponent();
        
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        CarrosViewModel carros = new CarrosViewModel();
    }


    private async void btnRentar_Clicked(object sender, EventArgs e)
    {
        var tabbedPage = Application.Current.MainPage as Menu;
        RentarCarro rentarCarro = tabbedPage.Children[2] as RentarCarro;

        var carroSeleccionado = (Carros)ListaCarros.SelectedItem;

        if (carroSeleccionado != null)
        {
            rentarCarro.RellenarDatos(carroSeleccionado.Placas.ToString(), carroSeleccionado.Precio.ToString());
            //var mensaje = $"Marca: {carroSeleccionado.Marca}\nModelo: {carroSeleccionado.Modelo}\nA�o: {carroSeleccionado.A�o}";
            //await DisplayAlert("Informaci�n del veh�culo", mensaje, "Ok");
        }
        else
        {
            await DisplayAlert("Error", "No se ha seleccionado ning�n veh�culo.", "Ok");
        }
    }
}
