 

using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using Sitecore.DevEx.Client.Tasks;
using Sitecore.DevEx.Extensibility.Hachathon.Tasks;
using System;
using System.CommandLine;
using System.Threading.Tasks;

namespace Sitecore.DevEx.Extensibility.Hachathon.Commands
{
    public class MigrateCommand : SubcommandBase<ToolsTask, ToolsTaskOptions>
    {
        public MigrateCommand(IServiceProvider container)
          : base("migrate", "Do Something", container)
        {
            ((Command)this).AddOption(ArgOptions.EnvironmentName);
            ((Command)this).AddOption(ArgOptions.Config);
            ((Command)this).AddOption(ArgOptions.Trace);
        }

        protected override async Task<int> Handle(ToolsTask task, ToolsTaskOptions args)
        {
            ((TaskOptionsBase)args).Validate();
            await task.Execute(args).ConfigureAwait(false);
            return 0;
        }
 
    }
}
