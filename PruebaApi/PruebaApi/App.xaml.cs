using PruebaApi.Repository;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PruebaApi.View;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PruebaApi
{
    public partial class App : Application
    {
        public static RestManager Manager { get; set; }
        public App()
        {
            InitializeComponent();
            Manager = new RestManager();
            MainPage = new NavigationPage(new UsuarioView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
