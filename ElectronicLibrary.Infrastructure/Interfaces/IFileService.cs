using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Services
{
    public interface IFileService
    {
        Task<byte[]> ReadFileBytes(string path);
        Task Save(string path, IFormFile file);
    }
}