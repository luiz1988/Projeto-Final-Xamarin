using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using TestDrive.Data;
using TestDrive.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteAndroid))]
namespace TestDrive.Droid
{
    class SQLiteAndroid : ISQLite
    {
        private const string pathDB = "agenda.db3";

        public SQLiteConnection getConnection()
        {

            //Android.OS.Environment.ExternalStorageDirectory.Path

            var url = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var fullPathDB = Path.Combine(url, pathDB);

            SQLiteConnection connection = new SQLite.SQLiteConnection(fullPathDB);

            return connection;
        }
    }
}