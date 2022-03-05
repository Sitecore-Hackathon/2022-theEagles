using Sitecore.DevEx.Configuration.Models;
//using Sitecore.DevEx.Extensibility.Hackathon.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sitecore.DevEx.Extensibility.Hackathon.Services
{

    public interface IToolsService
    {
        Task<string> DoSomething(EnvironmentConfiguration configuration);

 
    }
}