using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sitecore.DependencyInjection;
using Sitecore.DevEx.Extensibility.HackathonApi.Controllers;
using Sitecore.DevEx.Extensibility.HackathonApi.Services;

namespace Sitecore.DevEx.Extensibility.HackathonApi
{
    [ExcludeFromCodeCoverage]
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            // Controllers
            serviceCollection.Replace(ServiceDescriptor.Transient(typeof(HackathonController),
                typeof(HackathonController)));
            
            // Services
            serviceCollection.AddTransient<IHackathonApiService, HackathonApiService>();
            
            
            ConfigureCacheCleaners(serviceCollection);
        }

        private static void ConfigureCacheCleaners(IServiceCollection serviceCollection)
        {
            //serviceCollection.AddTransient<IService, Service>();
 
        }
    }
}