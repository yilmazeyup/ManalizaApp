using ManalizaApp.Models;
using ManalizaApp.ViewModels;
using ManalizaApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManalizaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        IAuth auth;
        public HomePage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
            BindingContext = new DriversViewModel();


            MessagingCenter.Subscribe<CompanySelection, string>(this, "getCompanyData", (sender, value) =>
            {
                EntryCompany.Text = value;
            }
            );
            MessagingCenter.Subscribe<CompanySelection, string>(this, "getCompanyCodeData", (sender, value) =>
            {
                EntryCompanyCode.Text = value;
            }
            );

            MessagingCenter.Subscribe<CustomerSelection, string>(this, "getCustomerData", (sender, value) =>
            {

                EntryCustomer.Text = value;
            }
            );
            MessagingCenter.Subscribe<CompanySelection, string>(this, "getCustomerCodeData", (sender, value) =>
            {
                EntryCustomerCode.Text = value;
            }
            );
            MessagingCenter.Subscribe<StockSelection, string>(this, "getStockData", (sender, value) =>
            {

                EntryStock.Text = value;
            }
            );
            MessagingCenter.Subscribe<PlaceOfOperationSelection, string>(this, "getPlaceOfOperationData", (sender, value) =>
            {

                EntryPlaceOfOperation.Text = value;
            }
            );

        }

        public async void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var driver = args.Item as Driver;
            if (driver == null)
                return;
            await Navigation.PushAsync(new DriverDetailsPage(driver));
            lstDrivers.SelectedItem = null;
        }

        void SignOutButton_Clicked(object sender, EventArgs e)
        {
            var signOut = auth.SignOut();

            if (signOut)
            {
                Application.Current.MainPage = new MainPage();
            }

        }

        public async void ShowCompanySelectionPage(object sender,FocusEventArgs e)
        {

           await Navigation.PushAsync(new CompanySelection());
            
        }

        public async void ShowCustomerSelectionPage(object sender, FocusEventArgs e)
        {

            await Navigation.PushAsync(new CustomerSelection());

        }

        public async void ShowStockSelectionPage(object sender, FocusEventArgs e)
        {

            await Navigation.PushAsync(new StockSelection());

        }
        public async void ShowPlaceOfOperationSelectionPage(object sender, FocusEventArgs e)
        {

            await Navigation.PushAsync(new PlaceOfOperationSelection());

        }

    }

}