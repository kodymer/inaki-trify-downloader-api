using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TriFy.Car.Downloader.Dtos;
using TriFy.Car.Downloader.IO;
using TriFy.Car.Downloader.Settings;
using Volo.Abp;
using Volo.Abp.Settings;

namespace TriFy.Car.Downloader.Repuve;

[RemoteService(false)]
public class RepuveAppService : CarDownloaderAppService, IRepuveAppService
{
    private readonly ISettingProvider _settingProvider;
    private readonly IFileManager _fileManager;

    public RepuveAppService(
        ISettingProvider settingProvider,
        IFileManager fileGenerator)
    {

        Check.NotNull(fileGenerator, nameof(fileGenerator));

        _settingProvider = settingProvider;
        _fileManager = fileGenerator;
    }

    public async Task<RepuveFileDto> ExportAsync(RepuveFileInput input, CancellationToken cancellationToken = default)
    {
        var output = new RepuveFileDto();

        try
        {
            output.Buffer = await _fileManager.CreateAsync(input.UserId, input.HtmlContent);
            output.Filename = Path.ChangeExtension(input.Filename, "pdf");

            var canWriteFile = await _settingProvider.GetAsync(CarDownloaderSettings.Write.File.Default, false);
            if (canWriteFile)
            {
                var outputPath = await _settingProvider.GetOrNullAsync(CarDownloaderSettings.Write.File.OutputPath);
                await _fileManager.WriteAsync(output.Buffer, Path.Combine(outputPath, output.Filename));
            }
        }
        catch (Exception e)
        {
            Logger.LogError(e, "Could not export PDF file.");

            throw;
        }

        return output;
    }
}

