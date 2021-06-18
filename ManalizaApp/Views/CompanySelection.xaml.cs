using ManalizaApp.Models;
using ManalizaApp.Services;
using Firebase.Database;
using ManalizaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManalizaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanySelection : ContentPage
    {
        DBFirebase services;
        public CompanySelection()
        {
            InitializeComponent();

            BindingContext = new CompaniesViewModel();

        }

        private void lstCompanies_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myselecteditem=e.Item as Company;
            MessagingCenter.Send<CompanySelection, string>(this, "getCompanyCodeData", myselecteditem.CompanyCode);
            MessagingCenter.Send<CompanySelection, string>(this, "getCompanyData", myselecteditem.CompanyName);
            Navigation.PopAsync();
        }
    }
}


   
        

