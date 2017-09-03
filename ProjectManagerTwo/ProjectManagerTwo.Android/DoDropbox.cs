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
using Dropbox.Api;
using System.Threading.Tasks;
using Dropbox.Api.Files;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(DoDropbox))]
namespace ProjectManagerTwo.Droid
{

    class DoDropbox : IDoDropbox
    {
        DropboxClient dbx;
        public DoDropbox()
        {
            dbx = new DropboxClient("KbTGj5WuJkAAAAAAAAAAaMFlEvqB0KozSCJX-djC5LyyZhvRZUQnntxOH4T_DPb6");
            var task = Task.Run(Run);
            task.Wait();
        }

        static async Task Run()
        {
            using (var dbx = new DropboxClient("KbTGj5WuJkAAAAAAAAAAaMFlEvqB0KozSCJX-djC5LyyZhvRZUQnntxOH4T_DPb6"))
            {
                var full = await dbx.Users.GetCurrentAccountAsync();
            }
        }

        public async Task<FileMetadata> WriteFile(byte[] fileContent, string filename)
        {
            var full = await dbx.Users.GetCurrentAccountAsync();
            try
            {
                var commitInfo = new CommitInfo(filename, WriteMode.Overwrite.Instance, false, DateTime.Now);
                var metadata = await dbx.Files.UploadAsync(commitInfo, new MemoryStream(fileContent));
                return metadata;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<byte[]> DownloadFile(string file)
        {
            var full = await dbx.Users.GetCurrentAccountAsync();
            try
            {
                var response = await dbx.Files.DownloadAsync(file);
                var bytes = response?.GetContentAsByteArrayAsync();
                return bytes?.Result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> Download(string file, Label label)
        {
            var full = await dbx.Users.GetCurrentAccountAsync();

            var response2 = await dbx.Files.DownloadAsync("testiw.sqlite");
            var re = await response2.GetContentAsStringAsync();
            return re;
            //using (var response = await dbx.Files.DownloadAsync(file))
            //{
            //    label.Text = (await response.GetContentAsStringAsync());
            //    //return response.GetContentAsStringAsync();
            //}
        }

        public async Task Upload(string path, string fileContent)
        {
            var full = await dbx.Users.GetCurrentAccountAsync();

            using (var stream = new MemoryStream(System.Text.UTF8Encoding.UTF8.GetBytes(fileContent)))
            {
                var response = await dbx.Files.UploadAsync(path, WriteMode.Overwrite.Instance, body: stream);
            }
        }


        public async Task ListRootFolder(Label label)
        {
            var full = await dbx.Users.GetCurrentAccountAsync();
            var list = await dbx.Files.ListFolderAsync(string.Empty);

            // show folders then files
            foreach (var item in list.Entries.Where(i => i.IsFolder))
            {
                label.Text += item.Name;
            }

            foreach (var item in list.Entries.Where(i => i.IsFile))
            {
                label.Text += item.Name;
            }
        }

        public async Task<FolderMetadata> CreateFolder(string path)
        {
            var full = await dbx.Users.GetCurrentAccountAsync();
            var folderArg = new CreateFolderArg(path);
            var folder = await dbx.Files.CreateFolderAsync(folderArg);
            return folder;
        }

    }
}