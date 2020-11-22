using System;
using System.IO;
using Login.iOS.Persistent;
using Login.Persistent;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace Login.iOS.Persistent
{
    public class SQLiteDb : ISQLiteDb
    {
      public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite_1.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}
