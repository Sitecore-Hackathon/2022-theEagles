using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Devex.Client.Cli.Extensibility;
using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.CommandLine;
using Sitecore.DevEx.Extensibility.Hackathon.Commands;
using Microsoft.Extensions.Logging;
using Sitecore.DevEx.Extensibility.Hackathon.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sitecore.DevEx.Extensibility.Hackathon.Services;

namespace Sitecore.DevEx.Extensibility.Hackathon
{
    public class RegisterExtension : ISitecoreCliExtension
    {
        public IEnumerable<ISubcommand> AddCommands(IServiceProvider container) => (IEnumerable<ISubcommand>)new ISubcommand[1]
       {
             RegisterExtension.CreateAECommand(container)
       };

        [ExcludeFromCodeCoverage]
        public void AddConfiguration(IConfigurationBuilder configBuilder)
        {
        }

        public void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<CacheClearCommand>()
                .AddSingleton<ToolsTask>()
                .AddSingleton<IToolsService, ToolsService>()
                .AddSingleton(sp => sp.GetService<ILoggerFactory>().CreateLogger<ToolsTask>())
                .AddSingleton(sp => sp.GetService<ILoggerFactory>().CreateLogger<ToolsService>());

            serviceCollection.TryAddTransient<IEnvironmentConfigurationProvider, EnvironmentConfigurationProvider>();

            serviceCollection.AddHttpClient(Consts.HttpClientName, client =>
            {
                client.Timeout = TimeSpan.FromMinutes(5);
            })
               .ConfigurePrimaryHttpMessageHandler(x => new CompressionAwareHttpClientHandler());
        }

        private static ISubcommand CreateAECommand(IServiceProvider container)
        {
            AECommand aeCommand = new AECommand("ae", "misc tools for Sitecore CLI");
            aeCommand.AddAlias("ae");

            aeCommand.AddCommand( container.GetRequiredService<CacheClearCommand>());
 
            return aeCommand;
        }
    }
}
