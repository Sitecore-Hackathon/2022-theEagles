 
using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using System.CommandLine;

namespace Sitecore.DevEx.Extensibility.Hackathon.Commands
{
    public class AECommand : Command, ISubcommand
    {
        public AECommand(string name, string description = null)
          : base(name, description)
        {
        }
    }
}
