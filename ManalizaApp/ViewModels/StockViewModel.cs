using ManalizaApp.Models;
using ManalizaApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ManalizaApp.ViewModels
{
    public class StockViewModel : ContentPage
    {
        private DBFirebase services;


        private ObservableCollection<Stock> _stocks = new ObservableCollection<Stock>();
        public ObservableCollection<Stock> Stocks
        {
            get { return _stocks; }
            set
            {
                _stocks = value;
                OnPropertyChanged();
            }
        }




        public StockViewModel()
        {
            services = new DBFirebase();
            Stocks = services.getStock();

        }
    }
}
