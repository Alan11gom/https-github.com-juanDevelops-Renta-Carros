
namespace Renta_Carros;

public partial class AgregarCarro : ContentPage
{
	public AgregarCarro()
	{
		InitializeComponent();
	}

    db db = new db();
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
}