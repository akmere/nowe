using Dropbox.Api;
using Dropbox.Api.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectManagerTwo
{
    public interface IDoDropbox
    {
        Task<FileMetadata> WriteFile(byte[] fileContent, string filename);
        Task<byte[]> DownloadFile(string file);

        Task<string> Download(string file, Label label);
        Task Upload(string file, string content);

        Task ListRootFolder(Label label);
        Task<FolderMetadata> CreateFolder(string path);
    }
}
