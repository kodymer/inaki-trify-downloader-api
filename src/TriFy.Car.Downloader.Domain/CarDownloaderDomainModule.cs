using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TriFy.Car.Downloader.MultiTenancy;
using Volo.Abp.Domain;
using Volo.Abp.Emailing;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Settings;

namespace TriFy.Car.Downloader;

[DependsOn(
    typeof(CarDownloaderDomainSharedModule),
    typeof(AbpSettingsModule),
    typeof(AbpDddDomainModule)
)]
public class CarDownloaderDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddSingleton<IConverter>(new SynchronizedConverter(new PdfTools()));

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });

#if DEBUG
        context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
    }
}
