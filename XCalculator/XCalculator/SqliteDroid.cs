using SQLite;
using System.IO;
using Xamarin.Forms;
using XCalculator;

[assembly: Dependency(typeof(SQliteDroid))]
namespace XCalculator
{
    public class SQliteDroid : Isqlite
    {
        public SQLiteConnection GetConnection()
        {
            var dbase = "Mydatabase";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;

        }
    }
}
