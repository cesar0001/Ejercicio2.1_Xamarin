using Ejercicio2_1.View;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio2_1
{
    public partial class MainPage : ContentPage
    {
        string base64Val;
        public MainPage()
        {
            InitializeComponent();
        }

        public async void Informacion()
        {
            var f = new Model.foto
            {
                base_64 = base64Val,
                nombre = nombre.Text,
                descripcion = desc.Text
            };

            var resultado = await App.BaseDatos.Grabarfotov(f);

            if (resultado == 1)
            {
                await DisplayAlert("Mensaje", "Registro exitoso!!!", "ok");
                desc.Text = nombre.Text = base64Val = String.Empty;
             }
            else
            {
                await DisplayAlert("Error", "No se pudo Guardar", "ok");
            }
        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {

            var tomarfoto = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "miApp",
                Name = "Image.jpg"

            });

            if (tomarfoto != null)
            {
                imagen.Source = ImageSource.FromStream(() => { return tomarfoto.GetStream(); });
            }

            Byte[] imagenByte = null;

            using (var stream = new MemoryStream())
            {
                tomarfoto.GetStream().CopyTo(stream);
                tomarfoto.Dispose();
                imagenByte = stream.ToArray();

                 base64Val = Convert.ToBase64String(imagenByte);
                //await EmpleController.SubirImagen(imagenByte);
            }


        }

        private async void btngua_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(base64Val) == true)
            {
                await DisplayAlert("Error", "Carge una nueva foto", "ok");
            }
            else
            {
                Informacion();
            }
        }

        private async void btnl_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Listado());
        }
    }
}
