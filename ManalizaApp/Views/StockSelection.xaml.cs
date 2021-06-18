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
    public partial class StockSelection : ContentPage
    {
        DBFirebase services;
        public StockSelection()
        {
            InitializeComponent();

            BindingContext = new StockViewModel();

        }

        private void lstStocks_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myselecteditem = e.Item as Stock;
            MessagingCenter.Send<StockSelection, string>(this, "getStockCodeData", myselecteditem.StockCode);
            MessagingCenter.Send<StockSelection, string>(this, "getStockData", myselecteditem.StockName);
            Navigation.PopAsync();
        }
    }
}