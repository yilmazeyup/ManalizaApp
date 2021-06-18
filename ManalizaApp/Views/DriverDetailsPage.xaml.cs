using ManalizaApp.Models;
using ManalizaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Xamarin.Forms.Xaml;


namespace ManalizaApp.Views
{
    
    public partial class DriverDetailsPage : ContentPage
    {
        DBFirebase services;
        public DriverDetailsPage(Driver driver)
        {
            InitializeComponent();
            BindingContext = driver;
            services = new DBFirebase();
        }

        public async void BtnDelete_Driver(object sender, EventArgs e)
        {
            await services.DeleteDriver(FirstName.Text, LastName.Text, Plaque.Text, Company.Text, Customer.Text, Stock.Text, PlaceOfOperation.Text, CompanyCode.Text, CustomerCode.Text);
            await Navigation.PushAsync(new HomePage());
        }

        public async void BtnUpdate_Driver(object sender, EventArgs e)
        {
            await services.UpdateDriver(
                FirstName.Text, LastName.Text, Plaque.Text, Company.Text, Customer.Text, Stock.Text, PlaceOfOperation.Text, CompanyCode.Text, CustomerCode.Text
                );
            await Navigation.PushAsync(new HomePage());
        }
    }
}