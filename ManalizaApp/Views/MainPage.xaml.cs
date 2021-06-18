using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ManalizaApp
{
    public partial class MainPage : ContentPage
    {
        IAuth auth;
        public MainPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void LoginClicked(object sender, EventArgs e)
        {
            string token = await auth.LoginWithEmailAndPassword(EmailInput.Text, PasswordInput.Text);
            if (token != string.Empty)
            {
                await DisplayAlert("Giriş Başarılı", token, "Ok");
                Application.Current.MainPage = new HomePage();
            }
            else
            {
                await DisplayAlert("Giriş Başarısız", "Mail veya Şifre Yanlış", "Ok");
            }
        }

        void SignUpClicked(object sender, EventArgs e)
        {
            var signOut = auth.SignOut();

            if (signOut)
            {
                Application.Current.MainPage = new SignUpPage();
            }
        }
    }
}
