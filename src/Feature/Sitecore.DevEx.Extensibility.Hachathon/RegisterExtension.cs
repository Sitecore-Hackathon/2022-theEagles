using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Devex.Client.Cli.Extensibility;
using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.CommandLine;
using Sitecore.DevEx.Extensibility.Hachathon.Commands;
using Microsoft.Extensions.Logging;
using Sitecore.DevEx.Extensibility.Hachathon.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Sitecore.DevEx.Extensibility.Hachathon
{
    public class RegisterExtension : ISitecoreCliExtension
    {
        public IEnumerable<ISubcommand> AddCommands(IServiceProvider container) => (IEnumerable<ISubcommand>)new ISubcommand[1]
       {
             RegisterExtension.CreateIndexCommand(container)
       };

        [ExcludeFromCodeCoverage]
        public void AddConfiguration(IConfigurationBuilder configBuilder)
        {
        }

        public void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<MigrateCommand>()

                .AddSingleton(sp => sp.GetService<ILoggerFactory>().CreateLogger<ToolsTask>());
            
            serviceCollection.TryAddTransient<IEnvironmentConfigurationProvider, EnvironmentConfigurationProvider>();
                 }

        private static ISubcommand CreateIndexCommand(IServiceProvider container)
        {
            AECommand aeCommand = new AECommand("AE", "working with indexes data");
            ((Symbol)aeCommand).AddAlias("AE");

            aeCommand.AddCommand((Command)container.GetRequiredService<MigrateCommand>());
            aeCommand.AddCommand((Command)container.GetRequiredService<AECommand>());
 
            return (ISubcommand)aeCommand;
        }
    }
}
