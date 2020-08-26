using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Leviathanbadger.FeedScraper.Host.Configuration.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IMvcBuilder AddControllersFromAssembly(this IServiceCollection services, Type type)
        {
            return services.AddControllersFromAssembly(type.Assembly);
        }
        public static IMvcBuilder AddControllersFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            return services.AddControllers()
                           .AddControllersFromAssembly(assembly);
        }
        public static IMvcBuilder AddControllersFromAssembly(this IMvcBuilder mvcBuilder, Type type)
        {
            return mvcBuilder.AddControllersFromAssembly(type.Assembly);
        }
        public static IMvcBuilder AddControllersFromAssembly(this IMvcBuilder mvcBuilder, Assembly assembly)
        {
            mvcBuilder.PartManager.ApplicationParts.Add(new AssemblyPart(assembly));
            return mvcBuilder;
        }

        public static IServiceCollection AddHangfire(this IServiceCollection services, string connectionString)
        {
            return services.AddHangfire(cfg => cfg.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                                                  .UseSimpleAssemblyNameTypeSerializer()
                                                  .UseRecommendedSerializerSettings()
                                                  .UseSqlServerStorage(connectionString, new SqlServerStorageOptions
                                                  {
                                                      CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                                                      SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                                                      QueuePollInterval = TimeSpan.Zero,
                                                      UseRecommendedIsolationLevel = true,
                                                      DisableGlobalLocks = true
                                                  }))
                           .AddHangfireServer();
        }
    }
}
