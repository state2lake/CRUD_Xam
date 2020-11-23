using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.Persistent;
using Login.Models;
using SQLite;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Login.Views;

namespace Login
{

    public partial class MainPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<LoginModel> _loginModel;

        public MainPage()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        //Moved here - did not want mulitple expensive calls in the constructor 
        protected override async void OnAppearing()
        {
            //create the table
            await _connection.CreateTableAsync<LoginModel>();

            //get the results as a list and store in an object
            var result = await _connection.Table<LoginModel>().ToListAsync();
            //Observable Collection defined
            _loginModel = new ObservableCollection<LoginModel>(result);

            //clear list onAppearing 
            //_loginModel.Clear();

            //set the listviews itemsource to ObservableCollection
             loginDataListView.ItemsSource = _loginModel;

            base.OnAppearing();
        }


        async void OnAdd(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Registration());
        }
        //async void OnUpdate(object sender, EventArgs e)
        //{

        //    var item = _loginModel[0];
        //    item.Username += " UPDATED";

        //    await _connection.UpdateAsync(item);

        //}
    }
}
