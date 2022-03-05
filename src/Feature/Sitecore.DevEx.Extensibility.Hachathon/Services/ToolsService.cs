using GraphQL.Common.Request;
using Microsoft.Extensions.Logging;
using Sitecore.DevEx.Configuration.Models;
 
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sitecore.DevEx.Extensibility.Hachathon.Services
{
    public class ToolsService
    {
        private readonly ILogger<ToolsService> _logger;
 

        public ToolsService( 
            ILogger<ToolsService> logger)
        {
        
            _logger = logger;
        }

        public async Task<string> DoSomething(EnvironmentConfiguration configuration)
        {
            const string apiPath = "sitecore/api/";
            

             return "something";
        }
    }
}
