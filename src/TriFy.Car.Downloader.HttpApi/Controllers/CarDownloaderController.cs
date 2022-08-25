using TriFy.Car.Downloader.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TriFy.Car.Downloader.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CarDownloaderController : AbpControllerBase
{
    protected CarDownloaderController()
    {
        LocalizationResource = typeof(CarDownloaderResource);
    }
}
