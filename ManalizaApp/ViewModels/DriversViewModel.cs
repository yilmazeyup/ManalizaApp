using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

using Xamarin.Forms;
using ManalizaApp.Models;
using MvvmHelpers;
using ManalizaApp.Services;
using System.Collections.ObjectModel;

namespace ManalizaApp.ViewModels
{
    public class DriversViewModel : ContentPage
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Plaque { get; set; }
        public string Company { get; set; }
        public string Customer { get; set; }
        public string Stock { get; set; }
        public string PlaceOfOperation { get; set; }
        public string CompanyCode { get; set; }
        public string CustomerCode { get; set; }

        private DBFirebase services;

        public Command AddEntryCommand { get; }

        private ObservableCollection<Driver> _drivers = new ObservableCollection<Driver>();
        public ObservableCollection<Driver> Drivers
        {
            get { return _drivers; }
            set
            {
                _drivers = value;
                OnPropertyChanged();
            }
        }

        public DriversViewModel()
        {
            services = new DBFirebase();
            Drivers = services.getDriver();
            AddEntryCommand = new Command(async () => await addDriverAsync(FirstName, LastName, Plaque, Company, Customer, Stock, PlaceOfOperation, CompanyCode, CustomerCode));
        }

        public async Task addDriverAsync(string FirstName, string LastName, string Plaque, string Company, string Customer, string Stock, string PlaceOfOperation, string Companycode, string Customercode)
        {
            await services.AddDriver(FirstName, LastName, Plaque, Company, Customer, Stock, PlaceOfOperation, Companycode, Customercode );
        }

        
    }
}