using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Services
{
    /// <summary>
    /// Service class for maintaining files
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// Saves file in provided path
        /// </summary>
        /// <param name="path">Path to save</param>
        /// <param name="file">File to save</param>
        /// <returns></returns>
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

        /// <summary>
        /// Method reading all file bytes from provided path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>Byte array</returns>
        public async Task<byte[]> ReadFileBytes(string path) =>
            await File.ReadAllBytesAsync(path);
    }
}
