using SQLite;

namespace XCalculator
{
    public interface Isqlite
    {
        SQLiteConnection GetConnection();

    }
}
