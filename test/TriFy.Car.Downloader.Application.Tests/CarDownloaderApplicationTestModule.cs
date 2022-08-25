using Volo.Abp.Modularity;

namespace TriFy.Car.Downloader;

[DependsOn(
    typeof(CarDownloaderApplicationModule),
    typeof(CarDownloaderDomainTestModule)
    )]
public class CarDownloaderApplicationTestModule : AbpModule
{

}
