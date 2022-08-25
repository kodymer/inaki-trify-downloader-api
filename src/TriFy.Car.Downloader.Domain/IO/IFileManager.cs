using System.Threading.Tasks;

namespace TriFy.Car.Downloader.IO
{
    public interface IFileManager
    {
        Task<byte[]> CreateAsync(string userId, string htmlContent);

        Task WriteAsync(byte[] buffer, string filename);
    }
}