using PruebaApi.Model;
using PruebaApi.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PruebaApi.ViewModel
{
    public class UsuarioEditViewModel
    {
        public UsuarioModel Usuario { get; set; }
        public Command GuardarCommand { get; set; }
        public Command BorrarCommand { get; set; }
        public bool EsNuevo { get; set; }

        public UsuarioEditViewModel()
        {

        }
        public UsuarioEditViewModel(bool Nuevo = true)
        {
            EsNuevo = Nuevo;
            Usuario = new UsuarioModel();
            GuardarCommand = new Command(Guardar);
            BorrarCommand = new Command(Borrar);
        }

         public UsuarioEditViewModel(bool nuevo, UsuarioModel UParametro)
        {
            EsNuevo = nuevo;
            Usuario = UParametro;
            GuardarCommand = new Command(Guardar);
            BorrarCommand = new Command(Borrar);
        }
        private async void Guardar()
        {
           await App.Manager.Usuario.GuardarItem(Usuario, EsNuevo);
           await App.Current.MainPage.Navigation.PushAsync(new UsuarioView());
        }
        private async void Borrar()
        {
            await App.Manager.Usuario.DeleteTodoItemAsync(Usuario.Id.ToString());
            await App.Current.MainPage.Navigation.PushAsync(new UsuarioView());
        }

    }
}
