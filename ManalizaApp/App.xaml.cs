using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManalizaApp
{
    public partial class App : Application
    {
        IAuth auth;
        public App()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();

            if (auth.IsSignIn())
            {
                MainPage = new HomePage();
            }
            else
            {
                MainPage = new MainPage();
            }

            MainPage = new NavigationPage(new HomePage());   

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
