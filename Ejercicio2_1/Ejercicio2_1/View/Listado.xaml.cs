using Ejercicio2_1.Controller;
using Ejercicio2_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listado : ContentPage
    {
        public Listado()
        {
            InitializeComponent();

            cargar();



        }

        public async void cargar()
        {
            List<foto> listaa = new List<foto>();


            listaa = await App.BaseDatos.ObtenerListafotov();


            list.ItemsSource = listaa;
        }

        private async void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            foto selected = e.SelectedItem as foto;
            if (selected == null)
                return;

            await Navigation.PushAsync(new Informacion(selected));
      

        }

        private void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            list.SelectedItem = null;
        }
    }
}