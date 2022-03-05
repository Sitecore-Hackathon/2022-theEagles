using Sitecore.DevEx.Extensibility.HackathonApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sitecore.DevEx.Extensibility.HackathonApi.Services
{
    public interface  IHackathonApiService
    {
        HackathonResultModel ClearCache();
    }
}
