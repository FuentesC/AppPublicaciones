using AppPublicaciones.Entidades.Request;
using Newtonsoft.Json;
using System.Text;
using AppPublicaciones.Entidades;
using AppPublicaciones.Entidades.Response;

namespace AppPublicaciones;

public partial class MainPage : ContentPage
{
	public String laURL = "https://apilatina.azurewebsites.net/api/Publicacion";

	public MainPage()
	{
		InitializeComponent();
	}

    private void btnPublicar_Clicked(object sender, EventArgs e)
    {
		this.enviarPubliacacion();
    }

	private async void enviarPubliacacion()
	{
		try {

            HttpClient httpClient = new HttpClient();
            ReqIngresarPublicacion req = new ReqIngresarPublicacion();
            req.laPublicacion = new Publicacion();

            req.laPublicacion.idTema = 1;
            req.laPublicacion.idUsuario = 1;
            req.laPublicacion.titulo = txtTitulo.Text;
            req.laPublicacion.mensaje = txtPublicacion.Text;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(laURL, jsonContent); //Aquí se envía en API

            if (response.IsSuccessStatusCode)
            {
                //El API respondió
                var responseContent = await response.Content.ReadAsStringAsync(); //Aquí recibo del API
                ResIngresarPublicacion res = new ResIngresarPublicacion();
                res = JsonConvert.DeserializeObject<ResIngresarPublicacion>(responseContent);

                if (res.result == true)
                {
                    DisplayAlert("Felicidades", "La publicacion se realizó con exito!!!", "Aceptar");
                }
                else
                {
                    DisplayAlert("Error en backend", res.ListaDeErrores.ToString(), "Acepto");
                }
            }
            else
            {
                //EL API está caído
                DisplayAlert("Error de conexion", "Intente mas tarde", "Aceptar");
            }

        } catch (Exception ex)	{
            DisplayAlert("Error", "Llore", "Aceptar");
        }
	}
}

