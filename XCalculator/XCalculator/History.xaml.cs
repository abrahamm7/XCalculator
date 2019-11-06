using SimpleInjector;
using SQLite;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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