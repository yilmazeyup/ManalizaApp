using ManalizaApp.Models;
using ManalizaApp.Services;
using ManalizaApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ManalizaApp.ViewModels
{
   
    public class CompaniesViewModel : ContentPage
    {
        
     


        private DBFirebase services;


        private ObservableCollection<Company> _companies = new ObservableCollection<Company>();
        public ObservableCollection<Company> Companies
        {
            get { return _companies; }
            set
            {
                _companies = value;
                OnPropertyChanged();
            }
        }


        

        public CompaniesViewModel()
        {
            services = new DBFirebase();
            Companies = services.getCompany();

        }   
        
        
        

                
    }
    
}
