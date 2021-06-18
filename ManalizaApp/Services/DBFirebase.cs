using Firebase.Database;
using Firebase.Database.Query;
using ManalizaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ManalizaApp.Services
{
    public class DBFirebase
    {
        FirebaseClient client;

        public DBFirebase()
        {
            client = new FirebaseClient("https://manalizaapplication-default-rtdb.firebaseio.com/");
        }
        
        public ObservableCollection<Driver> getDriver()
        {
            var driverData = client
                .Child("Drivers")
                .AsObservable<Driver>()
                .AsObservableCollection();
            return driverData;
        }

        public ObservableCollection<Company> getCompany()
        {
            var companyData = client
                .Child("Companies")
                .AsObservable<Company>()
                .AsObservableCollection();
            return companyData;
        }

        public ObservableCollection<Customer> getCustomer()
        {
            var customerData = client
                .Child("Customers")
                .AsObservable<Customer>()
                .AsObservableCollection();
            return customerData;
        }

        public ObservableCollection<Stock> getStock()
        {
            var stockData = client
                .Child("Stocks")
                .AsObservable<Stock>()
                .AsObservableCollection();
            return stockData;
        }
        public ObservableCollection<PlaceOfOperation> getPlaceOfOperation()
        {
            var placeofoperationData = client
                .Child("PlaceOfOperations")
                .AsObservable<PlaceOfOperation>()
                .AsObservableCollection();
            return placeofoperationData;
        }

        public async Task AddDriver(string firstName, string lastName, string plaque, string company, string customer, string stock, string placeofoperation, string companycode, string customercode)
        {
            Driver s = new Driver() { FirstName = firstName, LastName = lastName, Plaque = plaque, Company = company, Customer = customer, Stock = stock, PlaceOfOperation = placeofoperation, CompanyCode= companycode, CustomerCode= customercode };
            await client
                .Child("Drivers")
                .PostAsync(s);
        }

        public async Task UpdateDriver(string firstName, string lastName, string plaque, string company, string customer, string stock, string placeofoperation, string companycode, string customercode)
        {
            var toUpdateDriver = (await client
                .Child("Drivers")
                .OnceAsync<Driver>()).FirstOrDefault
                (a => a.Object.FirstName == firstName || a.Object.LastName == lastName || a.Object.Plaque == plaque || a.Object.Company == company || a.Object.Customer == customer || a.Object.Stock == stock || a.Object.PlaceOfOperation == placeofoperation || a.Object.CompanyCode == companycode || a.Object.CustomerCode == customercode);
            Driver s = new Driver() { FirstName = firstName, LastName = lastName, Plaque = plaque, Company = company, Customer = customer, Stock = stock, PlaceOfOperation = placeofoperation, CompanyCode = companycode, CustomerCode = customercode };
            await client
                .Child("Drivers")
                .Child(toUpdateDriver.Key)
                .PutAsync(s);
        }

        public async Task DeleteDriver(string firstName, string lastName, string plaque, string company, string customer, string stock, string placeofoperation, string companycode, string customercode)
        {
            var toDeleteDriver = (await client
                .Child("Drivers")
                .OnceAsync<Driver>()).FirstOrDefault
                (a => a.Object.FirstName == firstName || a.Object.LastName == lastName || a.Object.Plaque == plaque || a.Object.Company == company || a.Object.Customer == customer || a.Object.Stock == stock || a.Object.PlaceOfOperation == placeofoperation || a.Object.CompanyCode == companycode || a.Object.CustomerCode == customercode);
            await client.Child("Drivers").Child(toDeleteDriver.Key).DeleteAsync();
        }

    }
}