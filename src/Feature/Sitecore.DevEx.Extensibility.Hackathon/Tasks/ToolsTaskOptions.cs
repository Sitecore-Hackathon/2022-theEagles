using Sitecore.DevEx.Client.Tasks;

namespace Sitecore.DevEx.Extensibility.Hackathon.Tasks
{
    public class ToolsTaskOptions : TaskOptionsBase
    {
        public string Config { get; set; }

        public string EnvironmentName { get; set; }

        public override void Validate()
        {
            Require(nameof(Config));
            Default(nameof(EnvironmentName), "default");
        }
    }
}
