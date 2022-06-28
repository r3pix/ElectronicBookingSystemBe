using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Services
{
    /// <summary>
    /// Interface for FileService
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Method reading all file bytes from provided path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>Byte array</returns>
        Task<byte[]> ReadFileBytes(string path);

        /// <summary>
        /// Saves file in provided path
        /// </summary>
        /// <param name="path">Path to save</param>
        /// <param name="file">File to save</param>
        /// <returns></returns>
        Task Save(string path, IFormFile file);
    }
}