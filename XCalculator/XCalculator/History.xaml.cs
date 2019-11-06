using SimpleInjector;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalculator;

namespace XCalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class History : ContentPage
    {
        public SQLiteConnection conn;
        public Registration regmodel;
        public History()
        {
            InitializeComponent();
            conn = DependencyService.Get<Isqlite>().GetConnection();
            conn.CreateTable<Historial>();
            ShowFunction();

        }

        public void ShowFunction(){

            var details = (from x in conn.Table<Historial>() select x).ToList();
            myListView.ItemsSource = details;
        }
    }
}