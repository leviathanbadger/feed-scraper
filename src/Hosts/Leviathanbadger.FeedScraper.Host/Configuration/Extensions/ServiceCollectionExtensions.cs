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
    }
}
