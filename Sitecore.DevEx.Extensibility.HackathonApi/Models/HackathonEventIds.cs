using Microsoft.Extensions.Logging;

namespace Sitecore.DevEx.Extensibility.HackathonApi.Models
{
    public static class HackathonEventIds
    {
        public static readonly EventId ClearCache = new EventId(1, "ClearCache");
    }
}