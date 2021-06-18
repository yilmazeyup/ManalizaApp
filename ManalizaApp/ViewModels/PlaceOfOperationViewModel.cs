using ManalizaApp.Models;
using ManalizaApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ManalizaApp.ViewModels
{
    public class PlaceOfOperationViewModel : ContentPage
    {
        private DBFirebase services;


        private ObservableCollection<PlaceOfOperation> _placeofoperations = new ObservableCollection<PlaceOfOperation>();
        public ObservableCollection<PlaceOfOperation> PlaceOfOperations
        {
            get { return _placeofoperations; }
            set
            {
                _placeofoperations = value;
                OnPropertyChanged();
            }
        }




        public PlaceOfOperationViewModel()
        {
            services = new DBFirebase();
            PlaceOfOperations = services.getPlaceOfOperation();

        }
    }
}