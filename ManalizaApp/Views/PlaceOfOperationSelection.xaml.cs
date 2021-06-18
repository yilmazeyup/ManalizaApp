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
    public partial class PlaceOfOperationSelection : ContentPage
    {
        DBFirebase services;
        public PlaceOfOperationSelection()
        {
            InitializeComponent();

            BindingContext = new PlaceOfOperationViewModel();

        }

        private void lstPlaceOfOperations_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myselecteditem = e.Item as PlaceOfOperation;

            MessagingCenter.Send<PlaceOfOperationSelection, string>(this, "getPlaceOfOperationData", myselecteditem.PlaceOfOperationName);
            Navigation.PopAsync();
        }
    }
}