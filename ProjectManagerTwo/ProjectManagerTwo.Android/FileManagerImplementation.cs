using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using ProjectManagerTwo.Droid;
using System.Data.SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(FileManagerImplementation))]
namespace ProjectManagerTwo.Droid
{

    class FileManagerImplementation : IFileManager
    {
        string dbPath;
        public FileManagerImplementation()
        {
            dbPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "db3.sqlite");
            var db = new SQLiteConnection(dbPath);
        }

    }
}