using TriFy.Car.Downloader.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace TriFy.Car.Downloader;

[DependsOn(
    typeof(CarDownloaderApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule)
    )]
public class CarDownloaderHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CarDownloaderResource>();
        });
    }
}
