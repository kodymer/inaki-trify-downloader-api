using System.Threading;
using System.Threading.Tasks;
using TriFy.Car.Downloader.Dtos;

namespace TriFy.Car.Downloader
{
    public interface IRepuveAppService
    {
        Task<RepuveFileDto> ExportAsync(RepuveFileInput input, CancellationToken cancellationToken = default);
    }
}