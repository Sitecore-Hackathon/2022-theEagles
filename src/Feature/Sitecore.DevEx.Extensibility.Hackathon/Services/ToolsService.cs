using GraphQL.Common.Request;
using Microsoft.Extensions.Logging;
using Sitecore.DevEx.Client.Logging;
using Sitecore.DevEx.Configuration.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sitecore.DevEx.Extensibility.Hackathon.Models;

namespace Sitecore.DevEx.Extensibility.Hackathon.Services
{
    public class ToolsService:IToolsService
    {


        private readonly ILogger<ToolsService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;


        public ToolsService(
            IHttpClientFactory httpClientFactory,
            ILogger<ToolsService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        private HttpClient GetHttpClient(EnvironmentConfiguration configuration)
        {
            var httpClient = _httpClientFactory.CreateClient(Consts.HttpClientName);
            httpClient.BaseAddress = configuration.Host;
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        public async Task<HackathonResultModel> ClearCache(EnvironmentConfiguration configuration)
        {

            //call to the appi
             string api = Consts.apiPath + "/clearcache";
            _logger.LogConsoleInformation($"Processing...{api}", ConsoleColor.Yellow);
            _logger.LogTrace( "requesting clearing cache");

            var client = GetHttpClient(configuration);
            try
            {
                var response = await configuration
                    .MakeAuthenticatedRequest(client, _ => client.PostAsync(api, null))
                    .ConfigureAwait(false);

                var resultJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                // return resultJson;
               return JsonConvert.DeserializeObject<HackathonResultModel>(resultJson);
            }
            catch (Exception e)
            {
                _logger.LogTrace($"Error invoking API call {configuration.Host}{Consts.apiPath}");
                _logger.LogConsole(LogLevel.Error, e.Message);
            }

            return null;
          
        }
    }
}
