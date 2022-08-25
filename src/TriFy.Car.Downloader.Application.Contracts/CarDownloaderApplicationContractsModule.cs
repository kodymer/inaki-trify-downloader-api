using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace TriFy.Car.Downloader;

[DependsOn(
    typeof(CarDownloaderDomainSharedModule),
    typeof(AbpObjectExtendingModule)
)]
public class CarDownloaderApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        CarDownloaderDtoExtensions.Configure();
    }
}
