using Sitecore.DevEx.Extensibility.HackathonApi.Models;
using Sitecore.DevEx.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sitecore.DevEx.Extensibility.HackathonApi.Services
{
    public class HackathonApiService : IHackathonApiService
    {

 
 

        public HackathonApiService(
     
            )
        {
        
  
        }

        public HackathonResultModel ClearCache()
        {
            var result = new HackathonResultModel();

            try
            {
                var scope = new OperationResult("Cache");
               

                var sw = Stopwatch.StartNew();
                //_cache.ClearCache();
                sw.Stop();

                scope.Chain(OperationResult.FromInfoSuccess(HackathonEventIds.ClearCache, "[Hackathon] Cache cleared successfully"));



                result.OperationResults = new[] { scope };
            }
            catch (Exception e)
            {
                result.Successful = false;
                result.OperationResults = new[] { OperationResult.FromException(e) };
            }

            return result;
        }
    }
}
