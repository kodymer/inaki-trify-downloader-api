using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace TriFy.Car.Downloader;

[Dependency(ReplaceServices = true)]
public class CarDownloaderBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CarDownloader";
}
