using ManalizaApp.Models;
using ManalizaApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ManalizaApp.ViewModels
{
    public class CustomerViewModel : ContentPage
    {




        private DBFirebase services;


        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();
        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }




        public CustomerViewModel()
        {
            services = new DBFirebase();
            Customers = services.getCustomer();

        }





    }


}
