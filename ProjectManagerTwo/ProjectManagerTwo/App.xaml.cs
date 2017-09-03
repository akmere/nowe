using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dropbox.Api;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.IO;

namespace ProjectManagerTwo
{
    public partial class App : Application
    {
        static TodoItemDatabase database;

        public App()
        {
            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));
            InitializeComponent();

            MainPage = new MainPage();
        }

        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtTodoId { get; set; }

        protected override void OnStart()
        {
            Label label1 = MainPage.FindByName<Label>("label1");
            Label label2 = MainPage.FindByName<Label>("label2");
            var drop = DependencyService.Get<IDoDropbox>();
            drop.ListRootFolder(label1);
            TodoItemDatabase Connection = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("baza"));

            //drop.Download("", label2);
            //drop.CreateFolder("/Apps/ProjectManager1/mala");
            //drop.ListRootFolder(label1);
            //var x = drop.Download("warzywo.txt", label1);
            //x.Wait();
            //label1.Text = x.Result;
            //t.Wait();

            //MainPage.DisplayAlert("g", "g", "g");
            //var t = drop.DownloadFile("warzywo.txt");
            //t.Wait();
            //if (t.Result == null) MainPage.DisplayAlert("f", "f", "f"); else MainPage.DisplayAlert("z", "Zf", "zf");


            //Dropboxan Connector = new Dropboxan();


            //Connector.ListRootFiles(label1);
            //Connector.ListRootFolder(label2);
            //var file = Connector.ReadFile("temp.txt");
            //file.Wait();

            //var file = DependencyService.Get<IDoDropbox>().DownloadFile("warzywo.txt");
            //file.Wait();

            //label2.Text = DependencyService.Get<ISaveAndLoad>().LoadText("temp.txt").ToString();
            //var warzTask = DependencyService.Get<IDoDropbox>().Download("warzywo.txt");
            //warzTask.Start();
            //warzTask.Wait();


            //var dbTask = Connector.ReadFile("greatDatabase.sqlite");
            //dbTask.Wait();
            //dbTask.Start();
            //dbTask.Wait();
            //var db = dbTask.Result;
            //if (db == null) MainPage.DisplayAlert("f", "f", "f"); else MainPage.DisplayAlert("z", "Zf", "zf");
            //string sr = (new StreamReader(new MemoryStream(db)).ReadToEnd());
            //string sr = (new StreamReader(new MemoryStream(db)).ReadToEnd());
            //DependencyService.Get<IDoDropbox>().Upload("mako.db", sr);
            //var txtFile = Connector.ReadFile("heh.txt");
            //var warzFile = Connector.ReadFile("warzywo.txt");

            //DependencyService.Get<IDoDropbox>().Download("warzywo.txt");

            //DependencyService.Get<ISaveAndLoad>().SaveText("temp.txt", "lololololo");


        }



        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
