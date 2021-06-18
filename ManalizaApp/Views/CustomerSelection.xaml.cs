using ManalizaApp.Models;
using ManalizaApp.Services;
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
    public partial class CustomerSelection : ContentPage
    {
        DBFirebase services;
        public CustomerSelection()
        {
            InitializeComponent();

            BindingContext = new CustomerViewModel();
            
        }

        private void lstCustomers_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myselecteditem = e.Item as Customer;
            MessagingCenter.Send<CustomerSelection, string>(this, "getCustomerCodeData", myselecteditem.CustomerCode);
            MessagingCenter.Send<CustomerSelection, string>(this, "getCustomerData", myselecteditem.CustomerName);
            Navigation.PopAsync();
        }
    }
}