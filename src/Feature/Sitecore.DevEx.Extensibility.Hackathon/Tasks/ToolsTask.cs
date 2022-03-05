 

using Microsoft.Extensions.Logging;
using Sitecore.DevEx.Client.Logging;
using Sitecore.DevEx.Configuration.Models;
using Sitecore.DevEx.Extensibility.Hackathon.Services;
using Sitecore.DevEx.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sitecore.DevEx.Extensibility.Hackathon.Tasks
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
            var result = (await this._toolsService.ClearCache(configurationAsync).ConfigureAwait(false));

            _logger.LogTrace(string.Format("results: ", stopwatch.ElapsedMilliseconds, result));
            ColorLogExtensions.LogConsoleInformation(_logger, "result:", new ConsoleColor?(ConsoleColor.Yellow), new ConsoleColor?());
            stopwatch.Stop();

            if (result == null)
                return;

            PrintLogs(result.OperationResults);

            if (result.Successful)
            {
                ColorLogExtensions.LogConsoleInformation(_logger, "Successful" , new ConsoleColor?(ConsoleColor.Green), new ConsoleColor?());
            }

            stopwatch = (Stopwatch)null;
        }

        private void PrintLogs(IEnumerable<OperationResult> operationResults)
        {
            foreach (var operationResult in operationResults)
            {
                foreach (var message in operationResult.Messages)
                {
                    switch (message.LogLevel)
                    {
                        case LogLevel.Debug:
                            _logger.LogConsoleVerbose(message.Message, ConsoleColor.Yellow);
                            break;
                        case LogLevel.Information:
                            _logger.LogConsoleInformation(message.Message, ConsoleColor.Green);
                            break;
                        case LogLevel.Trace:
                        case LogLevel.Warning:
                        case LogLevel.Error:
                        case LogLevel.Critical:
                        case LogLevel.None:
                            _logger.LogConsole(message.LogLevel, message.Message);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }
    }
}
