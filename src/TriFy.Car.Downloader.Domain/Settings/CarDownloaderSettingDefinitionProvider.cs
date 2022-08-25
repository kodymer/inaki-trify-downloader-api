using Volo.Abp.Settings;

namespace TriFy.Car.Downloader.Settings;

public class CarDownloaderSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
            context.Add(new SettingDefinition(CarDownloaderSettings.Write.File.Default));
            context.Add(new SettingDefinition(CarDownloaderSettings.Write.File.OutputPath));
    }
}
