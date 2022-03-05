using System;
using System.Collections.Generic;
using Sitecore.DevEx.Logging;

namespace Sitecore.DevEx.Extensibility.HackathonApi.Models
{
    public class HackathonResultModel
    {

        public bool Successful { get; set; } = true;
        public IEnumerable<OperationResult> OperationResults { get; set; } = new List<OperationResult>();

    }
}
