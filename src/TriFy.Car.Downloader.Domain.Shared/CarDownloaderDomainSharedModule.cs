using TriFy.Car.Downloader.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace TriFy.Car.Downloader;

[DependsOn(
    typeof(AbpVirtualFileSystemModule),
    typeof(AbpLocalizationModule),
    typeof(AbpValidationModule)
    )]
public class CarDownloaderDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        CarDownloaderGlobalFeatureConfigurator.Configure();
        CarDownloaderModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CarDownloaderDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<CarDownloaderResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/CarDownloader");

            options.DefaultResourceType = typeof(CarDownloaderResource);
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("CarDownloader", typeof(CarDownloaderResource));
        });
    }
}
