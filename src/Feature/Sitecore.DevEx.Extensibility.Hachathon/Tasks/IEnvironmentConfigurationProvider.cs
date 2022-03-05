using Sitecore.DevEx.Configuration.Models;
using System.Threading.Tasks;

namespace Sitecore.DevEx.Extensibility.Hachathon.Tasks
{
    public interface IEnvironmentConfigurationProvider
    {
        Task<EnvironmentConfiguration> GetEnvironmentConfigurationAsync(
          string currentDirectory,
          string environmentName);
    }
}
