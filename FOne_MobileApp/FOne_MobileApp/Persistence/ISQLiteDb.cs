using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
