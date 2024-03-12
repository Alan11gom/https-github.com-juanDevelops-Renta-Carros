
namespace Renta_Carros;

public partial class AgregarCarro : ContentPage
{
	public AgregarCarro()
	{
		InitializeComponent();
	}

    dbMethods db = new dbMethods();
	String filePath = "";

    private async void btnAgregar_Clicked(object sender, EventArgs e)
    {
        // Validar que ninguno de los par�metros sea nulo
        if (!string.IsNullOrEmpty(tbMarca.Text) &&
            !string.IsNullOrEmpty(tbModelo.Text) &&
            !string.IsNullOrEmpty(tbA�o.Text) &&
            !string.IsNullOrEmpty(tbColor.Text) &&
            !string.IsNullOrEmpty(tbPlacas.Text) &&
            !string.IsNullOrEmpty(tbPrecio.Text) &&
            filePath != "")
        {
            // Llamar al m�todo InsertarCarro si todos los par�metros son v�lidos
            db.InsertarCarro(filePath, tbMarca.Text, tbModelo.Text, tbA�o.Text, tbColor.Text, tbPlacas.Text, tbPrecio.Text);
            await Navigation.PopAsync();
            await Navigation.PushAsync(new Prueba());
            await DisplayAlert("Aviso", "Nuevo auto registrado exitosamente.", "Ok");
        }
        else
        {
            await DisplayAlert("Error", "Todos los campos son requeridos", "Ok");
            return;
        }

        #region LIMPIAR CAMPOS
        tbMarca.Text = "";
		tbModelo.Text = "";
		tbA�o.Text = "";
		tbColor.Text = "";
		tbPlacas.Text = "";
		tbPrecio.Text = "";
		imgCarro.Source = "";
        #endregion
    }

    private async void btnCargarFoto_Clicked(object sender, EventArgs e)
    {
		try
		{
			var resultado = await MediaPicker.PickPhotoAsync();
			
            if (resultado != null)
			{
                filePath = resultado.FullPath;
                imgCarro.Source = ImageSource.FromStream(() => resultado.OpenReadAsync().Result);
			}
		}
		catch (Exception ex)
		{
			await DisplayAlert("Error", $"Error al cargar la imagen {ex.Message}", "Ok");
		}
    }

    public void RellenarDatos(string marca, string modelo, string a�o, string color, string placas, string precio, ImageSource source)
    {
        imgCarro.Source = source;
        tbMarca.Text = marca;
        tbModelo.Text = modelo;
        tbA�o.Text = a�o;
        tbColor.Text = color;
        tbPlacas.Text = placas;
        tbPrecio.Text = precio;
    }

    private void btnModificar_Clicked(object sender, EventArgs e)
    {
        //IPAddress[] addresses = Dns.GetHostAddresses("localhost");
        //foreach (IPAddress address in addresses)
        //{
        //    await DisplayAlert("Error", address.ToString(), "Ok");
        //}

        //await DisplayAlert("Error", db.GetLocalIPv4(), "Ok");
    }
}