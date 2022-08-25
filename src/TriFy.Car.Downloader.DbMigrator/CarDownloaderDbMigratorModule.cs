using TriFy.ExportAuto.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace TriFy.ExportAuto.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ExportAutoEntityFrameworkCoreModule),
    typeof(ExportAutoApplicationContractsModule)
    )]
public class ExportAutoDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
