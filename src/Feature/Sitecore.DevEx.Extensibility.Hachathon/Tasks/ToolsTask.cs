 

using Microsoft.Extensions.Logging;
using Sitecore.DevEx.Client.Logging;
using Sitecore.DevEx.Configuration.Models;
using Sitecore.DevEx.Extensibility.Hachathon.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sitecore.DevEx.Extensibility.Hachathon.Tasks
{
    public class ToolsTask
    {
        private readonly ILogger<ToolsTask> _logger;
        private readonly IToolsService _toolsService;
        private readonly IEnvironmentConfigurationProvider _configurationProvider;

        public ToolsTask(
          IToolsService toolsService,
          ILogger<ToolsTask> logger,
          IEnvironmentConfigurationProvider configurationProvider)
        {
            this._toolsService = toolsService;
            this._logger = logger;
            this._configurationProvider = configurationProvider;
        }

        public async Task Execute(ToolsTaskOptions args)
        {
            EnvironmentConfiguration configurationAsync = await this._configurationProvider.GetEnvironmentConfigurationAsync(args.Config, args.EnvironmentName);
            Stopwatch stopwatch = Stopwatch.StartNew();
            var result = (await this._toolsService.DoSomething(configurationAsync).ConfigureAwait(false)) ;

            this._logger.LogTrace(string.Format("results: ", stopwatch.ElapsedMilliseconds, result));
            ColorLogExtensions.LogConsoleInformation((ILogger)this._logger, "result:", new ConsoleColor?(ConsoleColor.Yellow), new ConsoleColor?());

            
            ColorLogExtensions.LogConsoleInformation((ILogger)this._logger, result, new ConsoleColor?(ConsoleColor.Green), new ConsoleColor?());

            stopwatch = (Stopwatch)null;
        }
    }
}