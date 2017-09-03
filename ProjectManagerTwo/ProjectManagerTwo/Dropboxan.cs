using Dropbox.Api;
using Dropbox.Api.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectManagerTwo
{
    class Dropboxan
    {
        DropboxClient dbx;
        public Dropboxan()
        {
            dbx = new DropboxClient("KbTGj5WuJkAAAAAAAAAAZu40QmK5gX-Ri2QOwWHKkuldbkSKISBQSO9aSr8S-Uae");
            Run(dbx);

        }

        static public async Task Run(DropboxClient dbx)
        {

            var full = await dbx.Users.GetCurrentAccountAsync();

        }

        async public Task ListRootFolder(Label label)
        {
            var list = await dbx.Files.ListFolderAsync(string.Empty);

            foreach (var item in list.Entries.Where(i => i.IsFolder))
            {
                label.Text += item.Name;
            }

        }
        async public Task ListRootFiles(Label label)
        {
            var list = await dbx.Files.ListFolderAsync(string.Empty);

            foreach (var item in list.Entries.Where(i => i.IsFile))
            {
                label.Text += item.Name;
            }
        }

        public async Task<byte[]> ReadFile(string file)
        {
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

        public async Task<FileMetadata> WriteFile(byte[] fileContent, string filename)
        {
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

        public async Task Upload(string file, string content)
        {
            using (var mem = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                var updated = await dbx.Files.UploadAsync(file,
                    WriteMode.Overwrite.Instance,
                    body: mem);
            }
        }


    }




}
