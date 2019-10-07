using PruebaApi.Model;
using PruebaApi.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace PruebaApi.ViewModel
{
    public class UsuarioViewModel:ClaseBase
    {
        private ObservableCollection<UsuarioModel> _ListaItems;

        public ObservableCollection<UsuarioModel> ListaItems
        {
            get { return _ListaItems; }
            set { _ListaItems = value; OnPropertyChanged();  }
        }

        public UsuarioModel ItemSelccionado { get; set; }

        public Command NuevoCommand { get; set; }
        public Command EditarCommand { get; set; }

        public UsuarioViewModel()
        {
            RecuperarItems();
            NuevoCommand = new Command(Nuevo);
            EditarCommand = new Command(Editar);
        }

        private void Editar()
        {
            var Pagina = new UsuarioEditView();
            Pagina.BindingContext = new UsuarioEditViewModel(false, ItemSelccionado);
            App.Current.MainPage.Navigation.PushAsync(Pagina);
        }

        private void Nuevo()
        {
            var Pagina = new UsuarioEditView();
            Pagina.BindingContext = new UsuarioEditViewModel(true);
            App.Current.MainPage.Navigation.PushAsync(Pagina);
        }

        private async void RecuperarItems()
        {
            var ListaTemporal = await App.Manager.Usuario.ObtenerItems();
            ListaItems = new ObservableCollection<UsuarioModel>(ListaTemporal);
        }


    }
}
