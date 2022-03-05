 

using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using Sitecore.DevEx.Client.Tasks;
using Sitecore.DevEx.Extensibility.Hackathon.Tasks;
using System;
using System.CommandLine;
using System.Threading.Tasks;

namespace Sitecore.DevEx.Extensibility.Hackathon.Commands
{
    public class CacheClearCommand : SubcommandBase<ToolsTask, ToolsTaskOptions>
    {
        public CacheClearCommand(IServiceProvider container)
          : base("clear", "clear the cache", container)
        {
            AddOption(ArgOptions.EnvironmentName);
            AddOption(ArgOptions.Config);
            AddOption(ArgOptions.Trace);
            AddOption(ArgOptions.ClearCache);
        }

        protected override async Task<int> Handle(ToolsTask task, ToolsTaskOptions args)
        {
            ((TaskOptionsBase)args).Validate();
            await task.Execute(args).ConfigureAwait(false);
            return 0;
        }
 
    }
}
