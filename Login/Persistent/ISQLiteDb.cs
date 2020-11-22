using System;
using SQLite;

namespace Login.Persistent
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
