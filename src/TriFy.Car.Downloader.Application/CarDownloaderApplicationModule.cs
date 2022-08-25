using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace TriFy.Car.Downloader;

[DependsOn(
    typeof(CarDownloaderDomainModule),
    typeof(CarDownloaderApplicationContractsModule),
    typeof(AbpDddApplicationModule)
    )]
public class CarDownloaderApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<CarDownloaderApplicationModule>();
        });
    }
}
