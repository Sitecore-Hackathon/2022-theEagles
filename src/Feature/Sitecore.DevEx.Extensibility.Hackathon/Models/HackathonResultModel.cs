using System;
using System.Collections.Generic;
using Sitecore.DevEx.Logging;

namespace Sitecore.DevEx.Extensibility.Hackathon.Models
{
    public class HackathonResultModel
    {
             public bool Successful { get; set; } 
            public IEnumerable<OperationResult> OperationResults { get; set; } = new List<OperationResult>();

    }
}
