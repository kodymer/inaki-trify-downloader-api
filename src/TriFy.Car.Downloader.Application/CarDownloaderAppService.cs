using System;
using System.Collections.Generic;
using System.Text;
using TriFy.Car.Downloader.Localization;
using Volo.Abp.Application.Services;

namespace TriFy.Car.Downloader;

/* Inherit your application services from this class.
 */
public abstract class CarDownloaderAppService : ApplicationService
{
    protected CarDownloaderAppService()
    {
        LocalizationResource = typeof(CarDownloaderResource);
    }
}
