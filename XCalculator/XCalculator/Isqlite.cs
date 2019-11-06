using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XCalculator
{
    public interface Isqlite
    {
        SQLiteConnection GetConnection();

    }
}
