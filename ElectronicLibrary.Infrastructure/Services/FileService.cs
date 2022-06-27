using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Services
{
    public class FileService : IFileService
    {
        public async Task Save(string path, IFormFile file)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var filePath = Path.Combine(path, file.FileName);

            var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.DisposeAsync();
        }

        public async Task<byte[]> ReadFileBytes(string path) =>
            await File.ReadAllBytesAsync(path);
    }
}
